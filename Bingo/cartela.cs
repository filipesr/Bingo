using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bingo
{
    class Cartela
    {
        string cod;
        List<int> nums = new List<int>();
        int sort = 0,
            sort1 = 0,
            sort2 = 0,
            sort3 = 0;
        private string msgErro = @"Cartela inválida!!
Cada cartela deve possuir 27 números, sendo 15 deles maiores que zero e 12 deles iguais a zero.
ex.: 0,0,05,15,11,0,0,20,24,0,0,31,48,0,0,50,0,57,0,63,68,78,71,0,81,84,0";

        public Cartela(string codigo, List<int> numeros)
        {
            cod = codigo;
            nums.AddRange(numeros);
            if (!ValidaCartela())
            {
                throw new Exception(msgErro);
            }
        }

        public Cartela(string codigo, string numeros)
        {
            cod = codigo;
            string[] vrs = numeros.Split(new char[] { ',' });
            int qtde = vrs.Length;
            if (qtde == 27)
            {
                foreach (string strNum in vrs)
                {
                    int intNum = -1;
                    if (int.TryParse(strNum, out intNum) && intNum >= 0 && intNum <= 90)
                    {
                        nums.Add(intNum);
                    }
                }
            }
            else
            {
                throw new Exception(msgErro);
            }
            if (!ValidaCartela())
            {
                throw new Exception(msgErro);
            }
        }

        private bool ValidaCartela()
        {
            int qtde0 = 0,
                qtdeV = 0;
            foreach (int n in nums)
            {
                if (n == 0)
                    qtde0++;
                else if (n > 0 && n <= 90)
                    qtdeV++;
            }
            return (qtde0 == 12) && (qtdeV == 15);
        }

        public string GetCodigo()
        {
            return cod;
        }

        public List<int> GetNumeros()
        {
            return nums;
        }
        public string GetNumeros(bool incluiZero)
        {
            string ret = string.Empty;
            foreach (int n in nums)
            {
                if (n > 0 || (n == 0 && incluiZero))
                {
                    if (!string.IsNullOrEmpty(ret))
                        ret += ", ";
                    if(n < 10)
                        ret += "0";
                    ret += n;
                }
            }
            return ret.Substring(1);
        }

        public int NumerosSorteados() { return sort; }
        public int MarcaPedra(int numero)
        {
            if (numero > 0 && nums.Contains(numero))
            {
                sort++;
                switch (nums.IndexOf(numero) % 3)
                {
                    case 0: sort1++;
                        break;
                    case 1: sort2++;
                        break;
                    case 2: sort3++;
                        break;
                }
            }
            return sort;
        }

        public int DesmarcaPedra(int numero)
        {
            if (numero > 0 && nums.Contains(numero))
            {
                sort--;
                switch (nums.IndexOf(numero) % 3)
                {
                    case 0: sort1--;
                        break;
                    case 1: sort2--;
                        break;
                    case 2: sort3--;
                        break;
                }
            }
            return sort;
        }

        public bool FileiraFechada(int numero)
        {
            switch (numero % 3)
            {
                case 0: return Fileira1Fechada();
                    break;
                case 1: return Fileira2Fechada();
                    break;
                case 2: return Fileira3Fechada();
                    break;
                default: return false;
                    break;
            }
        }

        public bool Fileira1Fechada()
        {
            return sort1 == 5;
        }

        public bool Fileira2Fechada()
        {
            return sort2 == 5;
        }
        
        public bool Fileira3Fechada()
        {
            return sort3 == 5;
        }

        public bool TemFileiraFechada()
        {
            return Fileira1Fechada() || Fileira2Fechada() || Fileira3Fechada();
        }

        public bool CartelaFechada()
        {
            return sort == 15;
        }
    }
}
