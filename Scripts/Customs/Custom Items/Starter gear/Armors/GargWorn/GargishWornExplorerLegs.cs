using System;
using Server.Items;

namespace Server.Items
{
	[Flipable]
	public class GargishWornExplorerLegs : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 10; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }
		
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		public override Race RequiredRace{ get { return Race.Gargoyle; } }
	

		[Constructable]
		public GargishWornExplorerLegs() : base( 0x0306 )
		{
            Name = "Worn Explorer Legs";
            Hue = 1159;
            Attributes.LowerRegCost = 20;
			Weight = 4.0;
		}

        public GargishWornExplorerLegs(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}