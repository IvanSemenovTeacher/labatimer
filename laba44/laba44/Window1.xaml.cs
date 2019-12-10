/*
 * Created by SharpDevelop.
 * User: Преподаватель
 * Date: 12/10/2019
 * Time: 08:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;

namespace laba44
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			Calendar cal = new Calendar();
			if( File.Exists("timer.txt"))
			{
				//string[] dt;
				string[] str = File.ReadAllLines("timer.txt");
				foreach(string s in str)
				{
					string[] nd = s.Split('#');
					list.Add(nd[0],Convert.ToDateTime( nd[1]));
					lb1.Items.Add(nd[0]);
				}
			}
		}
		Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();  
		void button1_Click(object sender, RoutedEventArgs e)
		{
			lb1.Items.Add(tb1.Text);
			list.Add(tb1.Text, calendar1.SelectedDate.Value); 
		}
		
		void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try{
			//MessageBox.Show(list[lb1.SelectedItem.ToString()].ToShortDateString());
			DateTime d1 = list[lb1.SelectedItem.ToString()];
			DateTime d2 = DateTime.Now;
			TimeSpan ts = d1-d2;
			label1.Content = "Дни:"+ts.Days+" Время: "+ts.Hours+":"+ts.Minutes+":"+ts.Seconds;
			}
			catch
			{}
			//MessageBox.Show("Дни:"+ts.Days+" Время: "+ts.Hours+":"+ts.Minutes+":"+ts.Seconds);
		}
		
		void button2_Click(object sender, RoutedEventArgs e)
		{
			list.Remove(lb1.SelectedItem.ToString());
			lb1.Items.Remove(lb1.SelectedItem.ToString());
		}
		
		void button3_Click(object sender, RoutedEventArgs e)
		{
			foreach(KeyValuePair<string,DateTime> keyvalue in list)
			{
				File.AppendAllText("timer.txt", keyvalue.Key+"#"+keyvalue.Value+Environment.NewLine);
			}
		}
	}
}