//By Tresdni
//www.uofreedom.com
using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Engines.XmlSpawner2
{
	public class XmlArtifactBonus : XmlAttachment
	{
		private int m_Value = 2;       // default value of 3x's drops.

		[CommandProperty(AccessLevel.GameMaster)]
		public int Value { get { return m_Value; } set { m_Value = value; } }

		// These are the various ways in which the message attachment can be constructed.  
		// These can be called via the [addatt interface, via scripts, via the spawner ATTACH keyword.
		// Other overloads could be defined to handle other types of arguments

		// a serial constructor is REQUIRED
		public XmlArtifactBonus(ASerial serial)
			: base(serial)
		{
		}

		[Attachable]
		public XmlArtifactBonus()
		{
		}

		[Attachable]
		public XmlArtifactBonus(int value)
		{
			m_Value = value;
			Expiration = TimeSpan.FromHours(24.0);
		}

		public override void OnAttach()
		{
			base.OnAttach();

			// apply the mod
			if (AttachedTo is Mobile)
			{
				Mobile m = AttachedTo as Mobile;
				Effects.PlaySound( m, m.Map, 516 );
				m.SendMessage(String.Format("You now have 3x artifact drops for two hours.  Happy hunting!"));
			}
		}
		
		public override void OnDelete()
		{
			base.OnDelete();

			if(AttachedTo is Mobile)
			{
				Mobile m = AttachedTo as Mobile;
				if(!m.Deleted)
				{
					Effects.PlaySound( m, m.Map, 958 );
					m.SendMessage(String.Format("Your increased artifact drops bonus fades away..."));
				} 
			}
		}
	}
}
