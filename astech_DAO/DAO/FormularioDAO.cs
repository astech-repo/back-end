using astech_DAO.DAO.Conexao;
using astech_DTO.DTO;
using astech_DTO.Validations;
using MySql.Data.MySqlClient;

namespace astech_DAO.DAO
{
    public class FormularioDAO
    {
        public async Task CadastrarFormulario(FormularioDTO formulario)
        {
            try
            {
                CepValidation cepValidation = new CepValidation();
                TelefoneValidation telefoneValidation = new TelefoneValidation();
                ImeiValidation imeiValidation = new ImeiValidation();

                if (await telefoneValidation.VerifyCellPhoneExistis(formulario.Usuario.Telefone))
                    throw new Exception("Telefone está cadastrado no sistema.");

                if (!await cepValidation.ValidateCep(formulario.Usuario.EnderecoCep, formulario.Usuario.EnderecoRua))
                    throw new Exception("CEP inválido ou não corresponde ao endereço informado.");

                if (!imeiValidation.ValidateIMEI(formulario.Aparelho.IMEI))
                    throw new Exception("IMEI inválido.");

                using (var conexao = ConnectionFactory.Build())
                {
                    await conexao.OpenAsync();

                    var query = @"
                            CALL InsertAparelhoProblema(
                                @tipo_aparelho, 
                                @marca, 
                                @modelo, 
                                @numero_serie,
                                @imei, 
                                @estado_garantia, 
                                @outras_especificacoes, 
                                @nome_usuario, 
                                @email, 
                                @telefone, 
                                @endereco_rua, 
                                @endereco_numero, 
                                @endereco_estado, 
                                @endereco_cep, 
                                @meio_de_contato,
                                @descricao, 
                                @conduta, 
                                @sintomas, 
                                @comportamento, 
                                @erro_alerta
                            );
                        ";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome_usuario", formulario.Usuario.Nome);
                        comando.Parameters.AddWithValue("@email", formulario.Usuario.Email);
                        comando.Parameters.AddWithValue("@telefone", formulario.Usuario.Telefone);
                        comando.Parameters.AddWithValue("@endereco_rua", formulario.Usuario.EnderecoRua);
                        comando.Parameters.AddWithValue("@endereco_numero", formulario.Usuario.EnderecoNumero);
                        comando.Parameters.AddWithValue("@endereco_estado", formulario.Usuario.EnderecoEstado);
                        comando.Parameters.AddWithValue("@endereco_cep", formulario.Usuario.EnderecoCep);
                        comando.Parameters.AddWithValue("@meio_de_contato", formulario.Usuario.MeioDeContato);

                        comando.Parameters.AddWithValue("@tipo_aparelho", formulario.Aparelho.TipoAparelho);
                        comando.Parameters.AddWithValue("@marca", formulario.Aparelho.Marca);
                        comando.Parameters.AddWithValue("@modelo", formulario.Aparelho.Modelo);
                        comando.Parameters.AddWithValue("@numero_serie", formulario.Aparelho.NumeroSerie);
                        comando.Parameters.AddWithValue("@imei", formulario.Aparelho.IMEI);
                        comando.Parameters.AddWithValue("@estado_garantia", formulario.Aparelho.EstadoGarantia);
                        comando.Parameters.AddWithValue("@outras_especificacoes", formulario.Aparelho.OutrasEspecificacoes);

                        comando.Parameters.AddWithValue("@descricao", formulario.Problema.Descricao);
                        comando.Parameters.AddWithValue("@conduta", formulario.Problema.Conduta);
                        comando.Parameters.AddWithValue("@sintomas", formulario.Problema.Sintomas);
                        comando.Parameters.AddWithValue("@comportamento", formulario.Problema.Comportamento);
                        comando.Parameters.AddWithValue("@erro_alerta", formulario.Problema.ErroAlerta);
                        await comando.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar formulário");
            }
        }
    }
}
