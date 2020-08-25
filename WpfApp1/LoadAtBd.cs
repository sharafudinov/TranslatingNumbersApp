using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class LoadAtBd
    {
        shiaEntities shia = new shiaEntities();
        int result;
        public int ReturnSisSchis(int num, int SisScis)
        {
            switch (SisScis)
            {
                case 2:
                    result = shia.SisSchis.Where(x => x.id == num).Select(x => x.Binary).FirstOrDefault();
                    break;
                case 4:
                    result = shia.SisSchis.Where(x => x.id == num).Select(x => x.Quaternary).FirstOrDefault();
                    break;
                case 6:
                    result = shia.SisSchis.Where(x => x.id == num).Select(x => x.Hexadecimal).FirstOrDefault();
                    break;
                case 8:
                    result = shia.SisSchis.Where(x => x.id == num).Select(x => x.Octal).FirstOrDefault();
                    break;
                case 10:
                    result = shia.SisSchis.Where(x => x.id == num).Select(x => x.Decimal).FirstOrDefault();
                    break;
            }
            return result;
        }

        int idd;
        public int ReturnResultMathOper(int num1, int num2, int SisIsch)
        {
            switch (SisIsch)
            {
                case 2:

                    idd = shia.OperOnChiss.Include(i => i.SisSchis).Where(w => w.id_num == num1 && w.id_num2 == num2).Select(s => s.Resulters).FirstOrDefault();
                    result = shia.SisSchis.Where(w => w.id == idd).Select(s=>s.Binary).FirstOrDefault();
                    break;
                case 4:
                    idd = shia.OperOnChiss.Include(i => i.SisSchis).Where(w => w.id_num == num1 && w.id_num2 == num2).Select(s => s.Resulters).FirstOrDefault();
                    result = shia.SisSchis.Where(w => w.id == idd).Select(s => s.Quaternary).FirstOrDefault();
                    break;
                case 6:
                    idd = shia.OperOnChiss.Include(i => i.SisSchis).Where(w => w.id_num == num1 && w.id_num2 == num2).Select(s => s.Resulters).FirstOrDefault();
                    result = shia.SisSchis.Where(w => w.id == idd).Select(s => s.Hexadecimal).FirstOrDefault();
                    break;
                case 8:
                    idd = shia.OperOnChiss.Include(i => i.SisSchis).Where(w => w.id_num == num1 && w.id_num2 == num2).Select(s => s.Resulters).FirstOrDefault();
                    result = shia.SisSchis.Where(w => w.id == idd).Select(s => s.Octal).FirstOrDefault();
                    break;
                case 10:
                    idd = shia.OperOnChiss.Include(i => i.SisSchis).Where(w => w.id_num == num1 && w.id_num2 == num2).Select(s => s.Resulters).FirstOrDefault();
                    result = shia.SisSchis.Where(w => w.id == idd).Select(s => s.Decimal).FirstOrDefault();
                    break;
            }
            return result;
        }
    }
}
