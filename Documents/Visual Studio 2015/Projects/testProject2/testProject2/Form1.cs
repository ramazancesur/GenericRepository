﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testProject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void mytest<T> (T table) where T :class
        {
            Type type = table.GetType();
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Name);
            foreach (var item in type.GetFields())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(type.GetField("id"));

        }
        test test;
        test2 test2;
        private void button1_Click(object sender, EventArgs e)
        {
            test = new test();
            test2 = new test2();
            mytest(test);
            mytest(test2);
        }
    }
}
