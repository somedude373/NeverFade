//By Tresdni & SHAMBAMPOW
//www.uofreedom.com
using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Factions;
using Server.Network;
using Server.Engines.XmlSpawner2;
using Server.Commands;
using Server.Targeting;

namespace Server.Mobiles
{
	public class ArtifactValidate
	{
		private static int multip = 1;
		private static double percent = 0.00;

		public static void ArtiChance(Mobile m, BaseCreature bc)
		{
			if( bc == null || bc.Deleted )
				return;
			
			double hits = (double)bc.GetHits();
			double stam = (double)bc.GetStam();
			double mana = (double)bc.GetMana();
			
			double fromluck = m.Luck;
			
			if(fromluck > (double)1200)
				fromluck = (double)1200;
			
			double luckscaler = (double)(1.0 + (fromluck / 1000));
			
						
			double artichance = luckscaler*( 20*(hits+stam+mana) / 6000);
			PlayerMobile pm = m as PlayerMobile;

			XmlArtifactBonus xab = (XmlArtifactBonus)XmlAttach.FindAttachment(pm, typeof(XmlArtifactBonus) );
			if (xab != null)
            {
				artichance *= xab.Value;
				if( artichance > 100.00 )
					artichance = 100.00;
				if( artichance < 0.00 )
					artichance = 0.00;              
				percent = artichance/100.00;
				
				if( m.AccessLevel > AccessLevel.GameMaster )
					m.SendMessage( "[GM DEBUG] {0}% drop chance.", percent*100);
			}
			else
			{
				if( artichance > 100.00 )
				artichance = 100.00;
				if( artichance < 0.00 )
				artichance = 0.00;              
				percent = artichance/100.00;
				
				if( m.AccessLevel > AccessLevel.GameMaster )
					m.SendMessage( "[GM DEBUG] {0}% chance.", percent*100);
			}
			

		}
		
		public static void GiveArtifact(Mobile m, PlayerMobile pm)
		{
			//**Begin Artifact Randomness**\\
			
			if ( percent >= Utility.RandomDouble() && pm != null && !pm.Deleted)
			{
				Container artybag = GetArtifactBag( m );
				//bc.PackItem(ArtifactList.RandomArtifact());
				m.SendMessage( 87, "For your valor in combating the fallen beast, a special artifact has been bestowed on you." );
				if( m.Backpack != null && m.Backpack.Items != null && m.Backpack.Items.Count < 125 )	// randomize the drop if pack isn't full.
					artybag.DropItem( ArtifactList.RandomArtifact() );
				else artybag.AddItem( ArtifactList.RandomArtifact() );
			}
				
		}
		public static void MultiP(int size)
		{
			multip = size;
		}
		
		public static Container GetArtifactBag( Mobile from )
		{
			Container lootBag = from.Backpack.FindItemByType( typeof(ArtifactBag) ) as Container;
			return ( null == lootBag ) ? from.Backpack : lootBag;
		}
	}
	
	
	
	public class ArtyChanceCommand
    {
    	public static void Initialize()
        {
            CommandSystem.Register("ArtyChance", AccessLevel.Player /*Changed from GM Debug command to a player command*/, new CommandEventHandler(ArtyChance_OnCommand));
        }
    	
    	private static void ArtyChance_OnCommand(CommandEventArgs e)
        {	
			if( e == null || e.Mobile == null ) return;
			
			e.Mobile.Target = new ArtyChanceTarget();

        }
    }
	
	public class ArtyChanceTarget: Target
	{

		public ArtyChanceTarget()
			: base(30, true, TargetFlags.None)
		{
			CheckLOS = false;
		}
		protected override void OnTarget( Mobile from, object targeted )
		{
			if(from == null || targeted == null)
				return;
		
			if( targeted is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)targeted as BaseCreature;
				
				if( bc == null || bc.Deleted )
				{
					return;
				}
				else
				{
					
					double percent = 0.0;
										
					//int karma = Math.Abs( bc.Karma );
					//int fame = bc.Fame;
					double hits = (double)bc.HitsMax;
					double stam = (double)bc.StamMax;
					double mana = (double)bc.ManaMax;
					
					double fromluck = from.Luck;
					
					if(fromluck > (double)1200)
						fromluck = (double)1200;
					
					double luckscaler = (double)(1.0 + (fromluck / 1000));
						
					double artichance = luckscaler*( 20*(hits+stam+mana) / 6000);
					PlayerMobile pm = from as PlayerMobile;

					XmlArtifactBonus xab = (XmlArtifactBonus)XmlAttach.FindAttachment(pm, typeof(XmlArtifactBonus) );
					if (xab != null)
					{
						artichance *= xab.Value;
						if( artichance > 100.00 )
							artichance = 100.00;
						if( artichance < 0.00 )
							artichance = 0.00;              
						percent = artichance/100.00;
						
						//if( pm.AccessLevel > AccessLevel.GameMaster )
							pm.SendMessage( "{0}% chance.", percent*100);
					}
					else
					{
						if( artichance > 100.00 )
						artichance = 100.00;
						if( artichance < 0.00 )
						artichance = 0.00;              
						percent = artichance/100.00;
						
						//if( from.AccessLevel > AccessLevel.GameMaster )
							from.SendMessage( "{0}% chance.", percent*100);
					}
				}
			}
		}
	}
}
