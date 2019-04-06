using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class GargishStarterArmor : Bag
	{
		[Constructable]
		public GargishStarterArmor() : this(50)
		{

                        Hue = 1150;
			Name = "StarterArmor";
		}

		[Constructable]
		public GargishStarterArmor( int amount )
		{
            DropItem(new GargishWornExplorerWingArmor());
            DropItem(new GargishWornExplorerChest());
            DropItem(new GargishWornExplorerKilt());
            DropItem(new GargishWornExplorerArms());
            DropItem(new GargishWornExplorerLegs());
            DropItem(new GargishWornExplorerTalons());
		}

		public GargishStarterArmor( Serial serial ) : base( serial )
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