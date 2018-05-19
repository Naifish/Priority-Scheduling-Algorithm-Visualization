using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Priority_Scheduling_Algorithm_Visualization
{
    public partial class Form1 : Form
    {
        public int Total_processes, Arival_time, Priority, Burst_time, process_number = 2, input_range, fromX = 150, fromY = 250, pointer = 0, new_lb = 0, lable_pointer = 0, store_total_TAT = 0, moveX = 10, moveY = 10, movebox = 0, from_top = 0, from_left = 0, move_me = 0, check = 0, show_time = 0;

        public int point1 = 0, point2 = 0, point3 = 0;
        string Process_name;
        string[] names;
        int[] arv_time;
        int[] bs_time;
        int[] TAT_time;
        int[] resp_time;
        int[] prio;
        string[] row;
        int[] cop_bs_time;
        DataGridView dataGridView1, dataGridView2, dataGridView3;
        Label[] myLable;
        Timer t1, t2, t3;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get number of processes input for manage loop and array

            Total_processes = Convert.ToInt16(textBox1.Text);

            //geting value to manage table height

            input_range = Convert.ToInt16(textBox1.Text);

            //instantiating arrays

            names = new string[Total_processes];
            arv_time = new int[Total_processes];
            bs_time = new int[Total_processes];
            prio = new int[Total_processes];
            TAT_time = new int[Total_processes];
            resp_time = new int[Total_processes];
            myLable = new Label[Total_processes];
            //after number of process get

            textBox1.Enabled = false;
            button1.Enabled = false;

            //to enable the textboxes after geting no of process

            if (Total_processes != null)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //geting process name

            Process_name = textBox2.Text;

            //geting process arrival time

            Arival_time = Convert.ToInt16(textBox3.Text);

            //geting process burst time

            Burst_time = Convert.ToInt16(textBox4.Text);

            //geting process priority

            Priority = Convert.ToInt16(textBox5.Text);

            //to see which number of process name required

            label2.Text = "Process" + " " + process_number + " " + "Name";

            //visibling queue lable

            label13.Visible = true;

            //visibling processor lable

            label14.Visible = true;

            //creating processor uper Block

            Label uprPro = new Label();
            uprPro.Text = Process_name;
            uprPro.Size = new Size(100, 5);
            uprPro.Location = new Point(400, 170);
            uprPro.BackColor = Color.Black;
            this.Controls.Add(uprPro);

            //creating processor uper Block

            Label lvrPro = new Label();
            lvrPro.Text = Process_name;
            lvrPro.Size = new Size(100, 5);
            lvrPro.Location = new Point(400, 192);
            lvrPro.BackColor = Color.Black;
            this.Controls.Add(lvrPro);

            if (Priority == 1)
            {
                names[pointer] = Process_name;
                arv_time[pointer] = Arival_time;
                bs_time[pointer] = Burst_time;
                prio[pointer] = Priority;

                //clearing the values of all text boxes after geting input

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                //use pointer to index the arrays

                pointer++;

                //use to disable add processs button

                Total_processes--;

                //creating process of 1st priority


                myLable[lable_pointer] = new Label();
                myLable[lable_pointer].Text = "    " + names[lable_pointer] + " ser = " + bs_time[lable_pointer];
                myLable[lable_pointer].Size = new Size(100, 20);
                myLable[lable_pointer].Location = new Point(fromX, fromY);
                myLable[lable_pointer].BackColor = Color.Red;
                this.Controls.Add(myLable[lable_pointer]);

                //using lable_pointer to create new lable evere time

                lable_pointer++;

                //updating value of y-axis so the space between processes can be visible

                fromY = fromY + 22;

                //doing for lable2

                process_number++;

                //to disable Add Process button and to create table

                if (Total_processes == 0)
                {

                    button2.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;

                    //visibling processes info lable

                    label12.Visible = true;

                    //creating table

                    dataGridView1 = new DataGridView();
                    dataGridView1.Location = new Point(400, 400);
                    dataGridView1.Size = new Size(660, 40 * input_range);
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Process Name";
                    dataGridView1.Columns[1].Name = "Priority";
                    dataGridView1.Columns[2].Name = "Arrival Time";
                    dataGridView1.Columns[3].Name = "Burst Time";
                    dataGridView1.Columns[4].Name = "Responce Time";
                    dataGridView1.Columns[5].Name = "Total Turnarround Time";
                    for (int i = 0; i < names.Length; i++)
                    {
                        row = new string[] { names[i], prio[i].ToString(), arv_time[i].ToString(), bs_time[i].ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    this.Controls.Add(dataGridView1);
                }

            }
            else if (Priority == 2)
            {
                names[pointer] = Process_name;
                arv_time[pointer] = Arival_time;
                bs_time[pointer] = Burst_time;
                prio[pointer] = Priority;

                //clearing the values of all text boxes after geting input

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                //use pointer to index the arrays

                pointer++;

                //use to disable add processs button
                Total_processes--;

                //creating process of 2nd priority


                myLable[lable_pointer] = new Label();
                myLable[lable_pointer].Text = "    " + names[lable_pointer] + " ser = " + bs_time[lable_pointer];
                myLable[lable_pointer].Size = new Size(100, 20);
                myLable[lable_pointer].Location = new Point(fromX, fromY);
                myLable[lable_pointer].BackColor = Color.Green;
                this.Controls.Add(myLable[lable_pointer]);

                //using lable_pointer to create new lable evere time

                lable_pointer++;

                //updating value of y-axis so the space between processes can be visible

                fromY = fromY + 22;

                //doing for lable2

                process_number++;

                //to enable Add Process button and to create table

                if (Total_processes == 0)
                {
                    button2.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;

                    //visibling processes info lable

                    label12.Visible = true;

                    //creating table

                    dataGridView1 = new DataGridView();
                    dataGridView1.Location = new Point(400, 400);
                    dataGridView1.Size = new Size(660, 40 * input_range);
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Process Name";
                    dataGridView1.Columns[1].Name = "Priority";
                    dataGridView1.Columns[2].Name = "Arrival Time";
                    dataGridView1.Columns[3].Name = "Burst Time";
                    dataGridView1.Columns[4].Name = "Responce Time";
                    dataGridView1.Columns[5].Name = "Total Turnarround Time";
                    for (int i = 0; i < names.Length; i++)
                    {
                        row = new string[] { names[i], prio[i].ToString(), arv_time[i].ToString(), bs_time[i].ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    this.Controls.Add(dataGridView1);
                }

            }
            else if (Priority == 3)
            {
                names[pointer] = Process_name;
                arv_time[pointer] = Arival_time;
                bs_time[pointer] = Burst_time;
                prio[pointer] = Priority;

                //clearing the values of all text boxes after geting input

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                //use pointer to index the arrays

                pointer++;

                //use to disable add processs button
                Total_processes--;

                //creating process of 3rd priority


                myLable[lable_pointer] = new Label();
                myLable[lable_pointer].Text = "    " + names[lable_pointer] + " ser = " + bs_time[lable_pointer];
                myLable[lable_pointer].Size = new Size(100, 20);
                myLable[lable_pointer].Location = new Point(fromX, fromY);
                myLable[lable_pointer].BackColor = Color.Blue;
                this.Controls.Add(myLable[lable_pointer]);

                //using lable_pointer to create new lable evere time

                lable_pointer++;

                //updating value of y-axis so the space between processes can be visible

                fromY = fromY + 22;

                //doing for lable2

                process_number++;

                //to enable Add Process button and to create table

                if (Total_processes == 0)
                {
                    button2.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;

                    //visibling processes info lable

                    label12.Visible = true;

                    //creating table


                    dataGridView1 = new DataGridView();
                    dataGridView1.Location = new Point(400, 400);
                    dataGridView1.Size = new Size(660, 40 * input_range);
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Process Name";
                    dataGridView1.Columns[1].Name = "Priority";
                    dataGridView1.Columns[2].Name = "Arrival Time";
                    dataGridView1.Columns[3].Name = "Burst Time";
                    dataGridView1.Columns[4].Name = "Responce Time";
                    dataGridView1.Columns[5].Name = "Total Turnarround Time";
                    for (int i = 0; i < names.Length; i++)
                    {
                        row = new string[] { names[i], prio[i].ToString(), arv_time[i].ToString(), bs_time[i].ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    this.Controls.Add(dataGridView1);
                }

            }

            else
            {
                //if priority is not 1,2 and 3

                MessageBox.Show("priority can be 1,2 or 3 please enter a valid priority");
            }
        }
    }
}
