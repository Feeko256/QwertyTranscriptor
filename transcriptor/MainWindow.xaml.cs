﻿using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace transcriptor
{

    public partial class MainWindow : Window
    {                                                                                                                                  //отсюда неввожимые с клавиатуры символы которые надо будет найти
        readonly string RU_Symbols = "ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю.Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ, –";
        readonly string EN_Symbols = "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>? –";
        int j;
        int i;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void But_Click_1(object sender, RoutedEventArgs e)
        {
            string line = text.Text;

            List<char> RU = new List<char> { };
            List<char> EN = new List<char> { };
            List<char> Line = new List<char> { };

            int k = 0;
            foreach (char a in line)
            {
                text.Clear();

                k++;
                Line.Add(a);
            }
            foreach (char a in RU_Symbols)
            {
                RU.Add(a);
            }
            foreach (char a in EN_Symbols)
            {
                EN.Add(a);
            }


            for (i = 0; i <= k - 1; i++)
            {
                for (j = 0; j <= 96; j++)
                {
                    if (combo.SelectedIndex == 1)
                    {
                        if (Line[i] == EN[j])
                        {
                            text.Text += RU[j];
                            break;
                        }
                        if (Line[i] == RU[j])
                        {
                            text.Text += Line[i];
                            break;
                        }
                    }

                    if (combo.SelectedIndex == 0)
                    {
                        if (Line[i] == RU[j])
                        {
                            text.Text += EN[j];
                            break;
                        }
                        if (Line[i] == EN[j])
                        {
                            text.Text += Line[i];
                            break;
                        }
                    }
                }
                j = 0;
            }
        }
        

        private void Text_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}