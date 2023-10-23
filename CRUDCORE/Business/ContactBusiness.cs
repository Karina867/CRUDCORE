using CRUDCORE.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDCORE.Business
{
    public class ContactBusiness
    {
        public List<ContactModel> getContacts()
        {
            var contactList = new List<ContactModel>();

            var cn = new Connection();

            // Establecer cadena de conexion
            using (var con = new SqlConnection(cn.getConnectionSql()))
            {
                con.Open();
                // estructura de commandos a ejecutar
                SqlCommand cmd = new SqlCommand("SP_Get_Contacts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contactList.Add(new ContactModel()
                        {
                            IdCotact = Convert.ToInt32(dr["IdContact"]),
                            Name = dr["Name"].ToString(),
                            Phone = dr["PhoneNumber"].ToString(),
                            Email = dr["Email"].ToString()

                        });
                    }
                }

            }
            return contactList;
        }

        public ContactModel getContact(int IdContact)
        {
            var contact = new ContactModel();

            var cn = new Connection();

            // Establecer cadena de conexion
            using (var con = new SqlConnection(cn.getConnectionSql()))
            {
                con.Open();
                // estructura de commandos a ejecutar
                SqlCommand cmd = new SqlCommand("SP_Get_Contact", con);
                cmd.Parameters.AddWithValue("pIdContact", IdContact);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contact.IdCotact = Convert.ToInt32(dr["IdContact"]);
                        contact.Name = dr["Name"].ToString();
                        contact.Phone = dr["PhoneNumber"].ToString();
                        contact.Email = dr["Email"].ToString();
                    }
                }

            }
            return contact;
        }

        public bool addContact(ContactModel contact)
        {
            bool result;

            try
            {
                var cn = new Connection();

                // Establecer cadena de conexion
                using (var con = new SqlConnection(cn.getConnectionSql()))
                {
                    con.Open();
                    // estructura de commandos a ejecutar
                    SqlCommand cmd = new SqlCommand("SP_Save_Contact", con);
                    cmd.Parameters.AddWithValue("pName", contact.Name);
                    cmd.Parameters.AddWithValue("pPhone", contact.Phone);
                    cmd.Parameters.AddWithValue("pEmail", contact.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    result = true;

                }
            }
            catch (Exception e)
            {
                string error = e.Message + e.StackTrace;
                result = false;
            }
            return result;
        }

        public bool editContact(ContactModel contact)
        {
            bool result;

            try
            {
                var cn = new Connection();

                // Establecer cadena de conexion
                using (var con = new SqlConnection(cn.getConnectionSql()))
                {
                    con.Open();
                    // estructura de commandos a ejecutar
                    SqlCommand cmd = new SqlCommand("SP_Update_Contact", con);
                    cmd.Parameters.AddWithValue("pIdContact", contact.IdCotact);
                    cmd.Parameters.AddWithValue("pName", contact.Name);
                    cmd.Parameters.AddWithValue("pPhone", contact.Phone);
                    cmd.Parameters.AddWithValue("pEmail", contact.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    result = true;

                }
            }
            catch (Exception e)
            {
                string error = e.Message + e.StackTrace;
                result = false;
            }
            return result;
        }
        public bool deleteContact(int Idcontact)
        {
            bool result;

            try
            {
                var cn = new Connection();

                // Establecer cadena de conexion
                using (var con = new SqlConnection(cn.getConnectionSql()))
                {
                    con.Open();
                    // estructura de commandos a ejecutar
                    SqlCommand cmd = new SqlCommand("SP_Delete_Contact", con);
                    cmd.Parameters.AddWithValue("pIdContact", Idcontact);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    result = true;

                }
            }
            catch (Exception e)
            {
                string error = e.Message + e.StackTrace;
                result = false;
            }
            return result;
        }

    }
}
