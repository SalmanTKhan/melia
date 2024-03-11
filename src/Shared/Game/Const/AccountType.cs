using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared.Game.Const
{
	/// <summary>
	/// 0-dev, 1-staff/partner, 2-tester/reviewer, 3-normal
	/// </summary>
	public enum AccountType : byte
	{
		Dev = 0,
		Staff = 1,
		Tester = 2,
		Normal = 3,
	}
}
