//By Tresdni
//www.uofreedom.com
using System;
using System.Reflection;
using System.IO;
using Server;
using Server.Items;

namespace Server
{
	public class ArtifactList
	{
		static int index;
		static Type type;

		public static Type[] ArtifactTypes = new Type[]
		{
			typeof( HatOfTheMagi ),
			typeof( SpiritOfTheTotem ),
			
		};
		public static Type[] Artifacts{ get{ return ArtifactTypes; } }

		public static Item RandomArtifact()
		{
			Item arty = null;

			index = Utility.Random( ArtifactTypes.Length );
			type = ArtifactTypes[index];
			return Activator.CreateInstance( type ) as Item;
		}
	}
}