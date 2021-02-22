using System.Collections.Generic;

namespace ExamenMasiv.Constants
{
    public class Constants
    {
        public const string SUCCESS = "0000";
        public const string ERROR_GENERIC = "1001";
        private static Dictionary<string, string> _Message;

        public static Dictionary<string, string> Message
        {
            get
            {
                return _Message ?? (_Message = new Dictionary<string, string>
                    {
                        {SUCCESS, "OK"},                        
                        {ERROR_GENERIC, "Ups! Ocurrió un error inesperado :(, por favor vuelve a intentarlo"},                        
                    });
            }
        }
        public static class RandomRuleta
        {
            public const int numberFrom = 1;
            public const int numberTo = 30;
        }
    }
}
