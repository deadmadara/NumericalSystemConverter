   //использование: ConvertNN.ConvertNto10(50,2)
class ConvertNN
    {
        //перевод числа number с оснований nbase в десятичное число - по формуле A = Mn * Q^n + Mn-1 * Q^(n-1) ...
        static public int ConvertNTo10(string number, int nbase)
        {
            int res = 0;
            if (number.Length != 0 && nbase <= 32)
            {
                int exp = 1;

                for (int i = 0; i < number.Length - 1; i++)
                    exp *= nbase;

                for (int i = 0; i < number.Length; i++)
                {
                    if (Char.IsDigit(number[i]))
                        res += (int)Char.GetNumericValue(number[i]) * exp;
                    else
                        res += ((int)number[i] - 55) * exp;
                    exp /= nbase;
                }
            }
            return res;
        }

        //перевод десятичного числа number в систему с основанием nbase - формируются остатки от деления с последующим переворотом строки
        static public string Convert10ToN(int number, int nbase)
        {
            string res = "";

            if (nbase <= 32)
            {
                while (number != 0)
                {
                    int mod = number % nbase;
                    if (mod < 10)
                        res += mod.ToString();
                    else res += Convert.ToChar(mod + 55);
                    number /= nbase;
                }

                char[] reverse = new char[res.Length];

                for (int i = 0; i < res.Length; i++)
                {
                    reverse[res.Length - 1 - i] = res[i];
                }
                res = new string(reverse);
            }
            return res;
        }

        //перевод числа number с основанием nbase1 в систему с основанием nbase2
        static public string ConvertNtoN(string number, int nbase1, int nbase2)
        {
            return Convert10ToN(ConvertNTo10(number, nbase1), nbase2);
        }
    }
