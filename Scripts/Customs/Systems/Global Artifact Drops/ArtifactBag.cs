// By: SHAMBAMPOW
using System;
using Server;

namespace Server.Items
{
    public class ArtifactBag : Bag
    {		
		[Constructable]
		public ArtifactBag() : base()
		{
			Weight = 0.0;
			Hue = 1172;
			Name = "an artifact bag";
			//LootType = LootType.Blessed;
		}

		public ArtifactBag( Serial serial ) : base( serial )
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
