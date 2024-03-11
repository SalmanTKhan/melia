using System.Linq;

namespace Melia.Shared.Game.Const.Web.Guild
{
	public static class GuildBanner
	{
		public static bool IsValidImageFormat(byte[] image)
		{
			var array = new byte[10];
			for (var i = 0; i < 10; i++)
			{
				array[i] = image[i];
			}
			var array2 = new byte[1][] { new byte[4] { 137, 80, 78, 71 } };
			foreach (var array3 in array2)
			{
				if (array3.SequenceEqual(array.Take(array3.Length)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsStandardSize(byte[] bytes, int fixWidth, int fixHeight)
		{
			var array = new byte[8];
			for (var i = 16; i < 24; i++)
			{
				array[i - 16] = bytes[i];
			}
			var num = 0;
			var num2 = 0;
			for (var j = 0; j <= 3; j++)
			{
				num = array[j] | (num << 8);
				num2 = array[j + 4] | (num2 << 8);
			}
			if (num == fixWidth && num2 == fixHeight)
			{
				return true;
			}
			return false;
		}
	}
}
