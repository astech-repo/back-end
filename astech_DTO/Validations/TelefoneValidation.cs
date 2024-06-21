using astech_DAO.DAO.Conexao;
using MySql.Data.MySqlClient;

namespace astech_DTO.Validations
{
    public class TelefoneValidation
    {
        public async Task<bool> VerifyCellPhoneExistis(string cellphone)
        {
            if (cellphone.Equals("")) return false;

            try
            {
                using (var conexao = ConnectionFactory.Build())
                {
                    await conexao.OpenAsync();

                    var query = @"
                        SELECT 
                            nome, email 
                        FROM 
                            tblUsuario 
                        WHERE 
                            telefone = @telefone
                    ";

                    var comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@telefone", cellphone);
                    var reader = comando.ExecuteReader();

                    if (reader.Equals(true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
