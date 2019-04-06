//By Tresdni
//www.uofreedom.com
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Spells;
using Server.Accounting;

namespace Server.Items
{
    public class RandomArtifactGiftScroll : Item
    {
        [Constructable]
        public RandomArtifactGiftScroll() : base (5360)
        {
	    	Name = "Random Artifact Coupon";
			Hue = 1175;
			LootType = LootType.Blessed;
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			else
			{
				if( from != null && from.Backpack != null )
				{
					Item item = ArtifactList.RandomArtifact();
					if( item != null )
					{
						from.Backpack.DropItem( item );
						this.Delete();
					}
					else from.SendMessage( "There was an issue with artifact generation, therefore the scroll does nothing" );
				}
				else if( from != null ) from.SendMessage( "You do not seem to have a backpack, therefore the scroll does nothing." );
			}
		}

        public RandomArtifactGiftScroll( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}