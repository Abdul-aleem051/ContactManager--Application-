using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewContactManager
{
    public static class Utility
{
    public static int? SelectEnum(string screenMessage, int validStart, int validEnd)
    {
        int outValue;

        while (true)
        {
            Console.Write(screenMessage);

            bool isParsable = int.TryParse(Console.ReadLine(), out outValue);

            if (!isParsable)
            {
                return null;
            }

            if (isParsable && (outValue >= validStart) && (outValue <= validEnd))
            {
                break;
            }
        }

        return outValue;
    }
}
}