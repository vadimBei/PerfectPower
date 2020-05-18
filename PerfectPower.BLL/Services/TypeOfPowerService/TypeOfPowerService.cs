using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Services.TypeOfPowerService
{
	public class TypeOfPowerService : ITypeOfPowerService
	{
		public TypeOfPower GetTypeOfPower(int power)
		{
			TypeOfPower typeOfPower;

			if (power == 2)
			{
				typeOfPower = TypeOfPower.PerfectSquare;
			}
			else if(power == 3)
			{
				typeOfPower = TypeOfPower.PerfectCube;
			}
			else
			{
				typeOfPower = TypeOfPower.PerfectPower;
			}

			return typeOfPower;
		}
	}
}
