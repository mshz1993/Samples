using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcurrencyControl
{
    public partial class FrmConcurrencyControl : Form
    {
        public FrmConcurrencyControl()
        {
            InitializeComponent();
        }

        #region Private Variable
        private byte[] CurrentRowversion;
        private string ConnectionString = @"Server=MASOUDTAHERI\SQLSERVER2017;DataBase=RowversionDemo;Integrated Security=SSPI";
        #endregion

        #region Custom Methods
        /// <summary>
        /// پاک کردن محتوای کلیه تکست باکس ها
        /// </summary>
        private void ClearAllTextBoxs()
        {
            txtStudentID2.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtHomeAddress.Clear();
            txtPhone.Clear();
            txtCurrentRowversion.Clear();
            CurrentRowversion = null;
        }

        /// <summary>
        /// جستجوی رکورد
        /// </summary>
        private void Search()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE StudentID = @StudentID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@StudentID";
                    param.Value = txtStudentID1.Text.Trim(); ;

                    cmd.Parameters.Add(param);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ClearAllTextBoxs();
                        if (reader.HasRows == false)
                        {
                            groupBoxStudentProperty.Enabled = false;
                            CurrentRowversion = null;
                            MessageBox.Show("رکوردی پیدا نشد");
                            txtStudentID1.Focus();
                        }
                        else
                        {
                            groupBoxStudentProperty.Enabled = true;
                        }
                        while (reader.Read())
                        {
                            txtStudentID2.Text = reader["StudentID"].ToString();
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtHomeAddress.Text = reader["HomeAddress"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            CurrentRowversion = (byte[])reader["CurrentRowversion"];
                            //var value = BitConverter.ToUInt64(CurrentRowversion.Reverse().ToArray(), 0);
                            var value = BitConverter.ToString(CurrentRowversion.ToArray(), 0).Replace("-", "");
                            txtCurrentRowversion.Text = String.Format("0X{0:X}", value);
                        }
                    }
                }
            }





        }

        private void UpdateRecord()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Students_Update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        /*
                                                @StudentID INT,
                            @FirstName NVARCHAR(100),
                            @LastName NVARCHAR(100),
                            @HomeAddress NVARCHAR(200),
                            @Phone VARCHAR(20),
                            @OldRowversion Rowversion 
                         * */
                        cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtStudentID2.Text.Trim();
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = txtFirstName.Text.Trim();
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = txtLastName.Text.Trim();
                        cmd.Parameters.Add("@HomeAddress", SqlDbType.NVarChar, 200).Value = txtHomeAddress.Text.Trim();
                        cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = txtPhone.Text.Trim();
                        cmd.Parameters.Add("@OldRowversion", SqlDbType.Binary).Value = CurrentRowversion;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("رکورد با موفقیت به روز رسانی شد");
                        Search();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 59999)
                {
                    MessageBox.Show("خطای همزمانی- اطلاعات رکورد مجددا واکشی خواهد شد");
                    ClearAllTextBoxs();
                    Search();
                }
            }
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int studentID = 0;
            bool studentIDTryParse;
            studentIDTryParse = Int32.TryParse(txtStudentID1.Text.Trim(), out studentID);
            if (studentIDTryParse == false || studentID <= 0)
            {
                MessageBox.Show("کد دانش آموزی معتبر نمی باشد");
                ClearAllTextBoxs();
                txtStudentID1.Clear();
                txtStudentID1.Focus();
            }
            else
            {
                Search();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            ClearAllTextBoxs();
            txtStudentID1.Clear();
            groupBoxStudentProperty.Enabled = false;
            txtStudentID1.Focus();
        }
    }
}
