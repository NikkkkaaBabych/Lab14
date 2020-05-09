using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab14_1
{
    
    public partial class Form1 : Form
    {

        static Food food1 = new Food("Борщ", 12.7);
        static Food food2 = new Food("Паста", 17.0);
        static Food food3 = new Food("Фри", 22.7);
        static Food food4 = new Food("Чай", 5);
        static Food food5 = new Food("Сок", 11.9);
        
        Meal meal1 = new Meal("комплект 1", new Food[] { food1, food2, food4 });
        Meal meal2 = new Meal("комплект 2", new Food[] { food1, food3, food5 });
        Meal meal3 = new Meal("комплект 3", new Food[] { food2, food3, food5 });
        
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string inlistbox = listBox1.SelectedItem.ToString();
            Meal a = new Meal();
            a.SetList(meal1);
            a.SetList(meal2);
            a.SetList(meal3);
            Meal A = a.FindMeal(inlistbox);
            label1.Text = A.MealInfo();

        }
    }
    public class Food
    {
        public double cost { get; private set; }
        public string name { get; private set; }
        public Food(string N, double C)
        {
            cost = C;
            name = N;
        }
    }
    public class Meal
    {
        double Cost;
        int Count;
        List<Food> components = new List<Food> { }; ///{ get; private set; }
        string ind;
        static List<Meal> meals = new List<Meal> { };
        public Meal() { }
        public Meal(string name, Food[] foods)
        {
            Cost = 0;
            Count = foods.Length;
            foreach (Food A in foods)
            {
                components.Add(A);
                Cost += A.cost;
            }
            ind = name;
        }
        public void SetList (Meal M)
        {
            meals.Add(M);
        }
        public string MealInfo()
        {
            string s = "В этом наборе количество блюд " + Count + " : ";
            foreach (Food f in components)
            {
                s += (f.name + " ( " + f.cost + " ), ");
            }
            s += " общая стоимость " + Cost;
            return s;

            
        }
        public Meal FindMeal(string inlistbox)
        {
            foreach (Meal A in meals)
            {
                if (inlistbox == A.ind)
                    return A; 
            }
            return null;
        }
    }
}