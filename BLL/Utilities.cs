using System;

namespace Utilities
{
    public class Utilities
    {
        public static int ToInt(string? cadena)
        {
            if(string.IsNullOrEmpty(cadena)||string.IsNullOrWhiteSpace(cadena))
            {
                return -1;
            }
            else
            {
                string numero="";
                foreach(var digito in cadena)
                {
                    if(char.IsNumber(digito))
                    {
                        numero+=digito;
                    }
                }
                if(string.IsNullOrEmpty(numero)||string.IsNullOrWhiteSpace(numero))
                {
                    return -1;
                }
                else
                {
                    return int.Parse(numero);
                }
            }
        }
        public static decimal ToDecimal(string? criterio)
        {
            if(!string.IsNullOrEmpty(criterio) || !string.IsNullOrWhiteSpace(criterio))
            {
                string numero = "";
                for(int i = 0; i<criterio.Length;i++)
                {
                    if (char.IsNumber(criterio[i])|| (criterio[i]=='.'))
                    {
                        if(numero.Contains('.') && criterio[i] == '.')
                            continue;
                        numero += criterio[i];
                    }
                }
                if(!string.IsNullOrEmpty(numero) || !string.IsNullOrWhiteSpace(numero))
                {
                    return Convert.ToDecimal(numero);
                }else{
                    return -1;
                }
            }else{
                return -1;
            }
        }
    }
} 