using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13FF, 0x13FE )]
	public class DemonHunterSword : BaseSword
	{   
	    public override int ArtifactRarity{ get{ return 11; } }
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 11; } }
		public override int AosMaxDamage{ get{ return 13; } }
		public override int AosSpeed{ get{ return 46; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 26; } }
		public override int OldSpeed{ get{ return 58; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 250; } }
		public override int InitMaxHits{ get{ return 250; } }

		[Constructable]
		public DemonHunterSword() : base( 0x13FF )
		{         
		         Name = "Demon Hunter's Sword";
                 Slayer = SlayerName.Exorcism;
		 Attributes.AttackChance = 15;
		 Attributes.BonusDex = 5;
		 Attributes.BonusHits = 10;
		 Attributes.BonusStr = 5;
		 WeaponAttributes.HitFireball = 50;
		 WeaponAttributes.HitLowerAttack = 40;
		 Attributes.SpellChanneling = 1;
			Weight = 6.0;
			Hue = 1644;
		}

		public DemonHunterSword( Serial serial ) : base( serial )
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