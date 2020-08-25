using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddForBd AFB = new AddForBd();
        LoadAtBd LAB = new LoadAtBd();
        AnyToDecimal ATD = new AnyToDecimal();
        DecimalToAny DTA = new DecimalToAny();
        MathOpertionSwitch MOS = new MathOpertionSwitch();
        CheckForAnyInconsistency CFAI = new CheckForAnyInconsistency();
        Check CHK = new Check();
        shiaEntities SHIA = new shiaEntities();

        public MainWindow()
        {
            InitializeComponent();
            comboboh.SelectedIndex = 0;
            comboboh_Copy.SelectedIndex = 0;
            comboboh_Copy1.SelectedIndex = 0;
        }

        private int returnmath(string ma)
        {
            if (ma == "+")
            {
                return 1;
            }
            else if (ma == "-")
            {
                return 2;
            }
            else if (ma == "*")
            {
                return 3;
            }
            else if (ma == "/")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //resulted.Text = DTA.DecimalToAn(enteredfirst.Text, comboboh_Copy1.Text);
            resulted.Text = "";
            bool check1 = CFAI.interstelar(enteredfirst.Text), check2 = CFAI.interstelar(enteredsecond.Text), check3 = false, check4 = false;
            int first=0, second=0, result=0, firstcheck = 0, secondcheck =0, resultcheck=0, MathOp = returnmath(comboboh_Copy2.Text);
            if (comboboh_Copy2.Text != "")
            {
                if (check1 == true && check2 == true)
                {
                    check3 = CFAI.checkerd(enteredfirst.Text, comboboh.Text, check1);
                    check4 = CFAI.checkerd(enteredsecond.Text, comboboh_Copy.Text, check2);
                    if (check3 == true && check4 == true)
                    {
                        if (comboboh.Text == "10" && comboboh_Copy.Text == "10")
                        {
                            firstcheck = CHK.check(Convert.ToInt32(enteredfirst.Text), 10);
                            secondcheck = CHK.check(Convert.ToInt32(enteredsecond.Text), 10);
                            if (firstcheck > 0 && secondcheck > 0)
                            {
                                resultcheck = CHK.CheckMathOperInBD(Convert.ToInt32(enteredfirst.Text), Convert.ToInt32(comboboh.Text), Convert.ToInt32(enteredsecond.Text), Convert.ToInt32(comboboh_Copy.Text), comboboh_Copy2.Text);
                                if (resultcheck > 0)
                                {
                                    resulted.Text = LAB.ReturnResultMathOper(firstcheck, secondcheck, Convert.ToInt32(comboboh_Copy1.Text)).ToString();
                                }
                                else
                                {
                                    first = Convert.ToInt32(enteredfirst.Text);
                                    second = Convert.ToInt32(enteredsecond.Text);
                                    result = MOS.mathoper(MathOp, first, second);
                                    AFB.insertSisSchis(result);
                                    AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                    if (comboboh_Copy1.Text == "10")
                                    {
                                        resulted.Text = result.ToString();
                                    }
                                    else
                                    {
                                        resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                    }
                                }
                            }
                            else if (firstcheck > 0 && secondcheck == 0)
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = Convert.ToInt32(enteredsecond.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else if (firstcheck == 0 && secondcheck > 0)
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = Convert.ToInt32(enteredsecond.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = Convert.ToInt32(enteredsecond.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                        }
                        else if (comboboh.Text == "10" && comboboh_Copy.Text != "10")
                        {
                            int checkc = ATD.alltodecimal(enteredsecond.Text, Convert.ToInt32(comboboh_Copy.Text));
                            firstcheck = CHK.check(Convert.ToInt32(enteredfirst.Text), 10);
                            secondcheck = CHK.check(checkc, 10);
                            if (firstcheck > 0 && secondcheck > 0)
                            {
                                resultcheck = CHK.CheckMathOperInBD(Convert.ToInt32(enteredfirst.Text), Convert.ToInt32(comboboh.Text), Convert.ToInt32(enteredsecond.Text), Convert.ToInt32(comboboh_Copy.Text), comboboh_Copy2.Text);
                                if (resultcheck > 0)
                                {
                                    resulted.Text = LAB.ReturnResultMathOper(firstcheck, secondcheck, Convert.ToInt32(comboboh_Copy1.Text)).ToString();
                                }
                                else
                                {
                                    first = Convert.ToInt32(enteredfirst.Text);
                                    second = checkc;
                                    result = MOS.mathoper(MathOp, first, second);
                                    AFB.insertSisSchis(result);
                                    AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                    if (comboboh_Copy1.Text == "10")
                                    {
                                        resulted.Text = result.ToString();
                                    }
                                    else
                                    {
                                        resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                    }
                                }
                            }
                            else if (firstcheck > 0 && secondcheck == 0)
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = checkc;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else if (firstcheck == 0 && secondcheck > 0)
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = checkc;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else
                            {
                                first = Convert.ToInt32(enteredfirst.Text);
                                second = checkc;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                        }
                        else if (comboboh.Text != "10" && comboboh_Copy.Text == "10")
                        {
                            int checkc = ATD.alltodecimal(enteredfirst.Text, Convert.ToInt32(comboboh.Text));
                            firstcheck = CHK.check(checkc, 10);
                            secondcheck = CHK.check(Convert.ToInt32(enteredsecond.Text), 10);
                            if (firstcheck > 0 && secondcheck > 0)
                            {
                                resultcheck = CHK.CheckMathOperInBD(Convert.ToInt32(enteredfirst.Text), Convert.ToInt32(comboboh.Text), Convert.ToInt32(enteredsecond.Text), Convert.ToInt32(comboboh_Copy.Text), comboboh_Copy2.Text);
                                if (resultcheck > 0)
                                {
                                    resulted.Text = LAB.ReturnResultMathOper(firstcheck, secondcheck, Convert.ToInt32(comboboh_Copy1.Text)).ToString();
                                }
                                else
                                {
                                    first = checkc;
                                    second = Convert.ToInt32(enteredfirst.Text);
                                    result = MOS.mathoper(MathOp, first, second);
                                    AFB.insertSisSchis(result);
                                    AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                    if (comboboh_Copy1.Text == "10")
                                    {
                                        resulted.Text = result.ToString();
                                    }
                                    else
                                    {
                                        resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                    }
                                }
                            }
                            else if (firstcheck > 0 && secondcheck == 0)
                            {
                                first = checkc;
                                second = Convert.ToInt32(enteredfirst.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else if (firstcheck == 0 && secondcheck > 0)
                            {
                                first = checkc;
                                second = Convert.ToInt32(enteredfirst.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else
                            {
                                first = checkc;
                                second = Convert.ToInt32(enteredfirst.Text);
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                        }
                        else
                        {
                            int checkc1 = ATD.alltodecimal(enteredfirst.Text, Convert.ToInt32(comboboh.Text));
                            int checkc2 = ATD.alltodecimal(enteredsecond.Text, Convert.ToInt32(comboboh.Text));
                            firstcheck = CHK.check(checkc1, 10);
                            secondcheck = CHK.check(checkc2, 10);
                            if (firstcheck > 0 && secondcheck > 0)
                            {
                                resultcheck = CHK.CheckMathOperInBD(Convert.ToInt32(enteredfirst.Text), Convert.ToInt32(comboboh.Text), Convert.ToInt32(enteredsecond.Text), Convert.ToInt32(comboboh_Copy.Text), comboboh_Copy2.Text);
                                if (resultcheck > 0)
                                {
                                    resulted.Text = LAB.ReturnResultMathOper(firstcheck, secondcheck, Convert.ToInt32(comboboh_Copy1.Text)).ToString();
                                }
                                else
                                {
                                    first = checkc1;
                                    second = checkc2;
                                    result = MOS.mathoper(MathOp, first, second);
                                    AFB.insertSisSchis(result);
                                    AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                    if (comboboh_Copy1.Text == "10")
                                    {
                                        resulted.Text = result.ToString();
                                    }
                                    else
                                    {
                                        resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                    }
                                }
                            }
                            else if (firstcheck > 0 && secondcheck == 0)
                            {
                                first = checkc1;
                                second = checkc2;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else if (firstcheck == 0 && secondcheck > 0)
                            {
                                first = checkc1;
                                second = checkc2;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                            else
                            {
                                first = checkc1;
                                second = checkc2;
                                result = MOS.mathoper(MathOp, first, second);
                                AFB.insertSisSchis(first);
                                AFB.insertSisSchis(second);
                                AFB.insertSisSchis(result);
                                AFB.insertOperWith(first, 10, second, 10, result, 10, comboboh_Copy2.Text);
                                if (comboboh_Copy1.Text == "10")
                                {
                                    resulted.Text = result.ToString();
                                }
                                else
                                {
                                    resulted.Text = DTA.DecimalToAn(result.ToString(), comboboh_Copy1.Text);
                                }
                            }
                        }
                    }
                    else if (check4 == true)
                    {
                        MessageBox.Show("первое число");
                    }
                    else
                    {
                        MessageBox.Show("второе число");
                    }
                }
                else if (check2 == true)
                {
                    MessageBox.Show("первое число");
                }
                else
                {
                    MessageBox.Show("второе число");
                }
            }
            else
            {
                MessageBox.Show("Не выбранн знак операции");
            }
        }

        public void clear()
        {
            enteredfirst.Clear();
            enteredsecond.Clear();
            comboboh.SelectedIndex = 0;
            comboboh_Copy.SelectedIndex = 0;
            comboboh_Copy1.SelectedIndex = 0;
            resulted.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
        }

        int CheckForBd, Firstter;

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            enteredfirst.Clear();
            enteredsecond.Clear();
            comboboh.SelectedIndex = 0;
            comboboh_Copy.SelectedIndex = 0;
        }

        private void Comboboh_Copy1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool check1 = CFAI.interstelar(Chis.Text), check2 = false;
            if (ChisSisSchis.Text == "" && ResultSisSchis.Text == "")
            {
                MessageBox.Show("Не выбраны системы счисления");
            }
            else if (ChisSisSchis.Text != "" && ResultSisSchis.Text == "")
            {
                MessageBox.Show("Не выбрана система счисления результата");
            }
            else if (ChisSisSchis.Text == "" && ResultSisSchis.Text != "")
            {
                MessageBox.Show("Не выбрана система счисления введенного числа");
            }
            else 
            {
                if (check1 == true)
                {
                    check2 = CFAI.checkerd(Chis.Text, ChisSisSchis.Text, check1);
                    if (check2 == true)
                    {
                        if (comboboh.Text == "10")
                        {
                            CheckForBd = CHK.check(Convert.ToInt32(Chis.Text), 10);
                            Firstter = Convert.ToInt32(Chis.Text);
                            if (CheckForBd > 0)
                            {
                                ResiltChis.Text = LAB.ReturnSisSchis(CheckForBd, Convert.ToInt32(ResultSisSchis.Text)).ToString();
                            }
                            else
                            {
                                AFB.insertSisSchis(Firstter);
                                ResiltChis.Text = DTA.DecimalToAn(Firstter.ToString(), ResultSisSchis.Text);
                            }
                        }
                        else
                        {
                            Firstter = ATD.alltodecimal(Chis.Text, Convert.ToInt32(ChisSisSchis.Text));
                            CheckForBd = CHK.check(Convert.ToInt32(Chis.Text), 10);
                            if (CheckForBd > 0)
                            {
                                ResiltChis.Text = LAB.ReturnSisSchis(CheckForBd, Convert.ToInt32(ResultSisSchis.Text)).ToString();
                            }
                            else
                            {
                                AFB.insertSisSchis(Firstter);
                                ResiltChis.Text = DTA.DecimalToAn(Firstter.ToString(), ResultSisSchis.Text);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Число введено некоректно");
                    }
                }
                else
                {
                    MessageBox.Show("Число введено некоректно");
                }
            }
            
        }
    }
}

