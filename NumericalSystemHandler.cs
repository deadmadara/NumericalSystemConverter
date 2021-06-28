    class NumericalSystemHandler
    {
        //пустой конструктор для использования методов
        public NumericalSystemHandler() { }

        //перевод числа number с оснований nbase в десятичное число - по формуле A = Mn * Q^n + Mn-1 * Q^(n-1) ...
        public int ConvertNTo10(string number, int nbase)
        {
            int res = 0;
            if (number.Length != 0)
            {
                int exp = 1;

                for (int i = 0; i < number.Length - 1; i++)
                    exp *= nbase;

                for (int i = 0; i < number.Length; i++)
                {
                    res += (int)Char.GetNumericValue(number[i]) * exp;
                    exp /= nbase;
                }
            }
            return res;
        }

        //перевод десятичного числа number в систему с основанием nbase - формируются остатки от деления с последующим переворотом строки
        public string Convert10ToN(int number, int nbase)
        {
            string res = "";

            while (number != 0)  
            {
                res += (number % nbase).ToString();
                number /= nbase;
            }

            char[] reverse = new char[res.Length];

            for (int i = 0; i < res.Length; i++)
            {
                reverse[res.Length - 1 - i] = res[i];
            }

            return new string(reverse);
        }

        //перевод числа number с основанием nbase1 в систему с основанием nbase2
        public string ConvertNtoN(string number, int nbase1, int nbase2)
        {
            return Convert10ToN(ConvertNTo10(number, nbase1), nbase2);
        }

    }