using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinForms_DZ_2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            Height = 720;
            Width  = 480;

            
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            FileStream fileStream = new FileStream("Info.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer serializer = new XmlSerializer(typeof(Info));
            info = (Info)serializer.Deserialize(fileStream);
            fileStream.Close();
            textBox_Name.Text = info.Name; 
            textBox_Surname.Text = info.Surname;
            textBox_Patronymic.Text = info.Patronymic;
            textBox_Sex.Text = info.Sex;
            textBox_FamilyStatus.Text = info.FamilyStatus;
            textBox_AddInfo.Text = info.AdditionalInfo;
            textBox_Day.Text = info.DateOfBirth.Day.ToString();
            textBox_Month.Text = info.DateOfBirth.Month.ToString();
            textBox_Year.Text = info.DateOfBirth.Year.ToString();


        }
        [OnSerializing]
        private void button_Save_Click(object sender, EventArgs e)
        {
            int day;
            int.TryParse(textBox_Day.Text, out day);
            int month;
            int.TryParse(textBox_Month.Text, out month);
            int year;
            int.TryParse(textBox_Year.Text, out year);

            Info info = new Info
            {
                Name = textBox_Name.Text,
                Surname = textBox_Surname.Text,
                AdditionalInfo = textBox_AddInfo.Text,
                Patronymic = textBox_Patronymic.Text,
                Sex = textBox_Sex.Text,
                FamilyStatus = textBox_FamilyStatus.Text,
                DateOfBirth = new DateTime(year, month, day)
            };
            FileStream fileStream = new FileStream("Info.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Info));
            serializer.Serialize(fileStream, info);
            fileStream.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    [Serializable]
    [DataContract]
    public class Info
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember] 
        public string Patronymic { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set;}
        [DataMember]
        public string AdditionalInfo { get; set;}
        [DataMember]
        public string FamilyStatus { get; set;}

        public Info()
        {
            
        }

    }
}
