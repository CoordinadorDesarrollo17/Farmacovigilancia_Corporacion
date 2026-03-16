using Dapper;
using Microsoft.Data.SqlClient;
using Sln_Farmacovigilancia_v2.Models;
using System.Data;

namespace Sln_Farmacovigilancia_v2.Repositorio
{


    public interface IRepositorioFarmacovigilancia
    {
        Task<int> Crear(datosFarmacovigilancia datosRegistro);
    }
    public class RepositorioFarmacovigilancia :IRepositorioFarmacovigilancia
    {
        private readonly string connectionString;

        public RepositorioFarmacovigilancia(IConfiguration configuration )
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> Crear(datosFarmacovigilancia datosRegistro)
        {
            using var connection = new SqlConnection(connectionString);

            var parameters = new DynamicParameters();

            parameters.Add("@Accion", 0);
            parameters.Add("@NombreCompletoPaciente", datosRegistro.nombrePaciente);
            parameters.Add("@EdadPaciente", datosRegistro.edadPaciente);
            parameters.Add("@SexoPaciente", datosRegistro.sexoPaciente);
            parameters.Add("@CelularPaciente", datosRegistro.celularPaciente);
            parameters.Add("@NombreProducto", datosRegistro.nombreProducto);
            parameters.Add("@DescripcionRAM", datosRegistro.descripcionRAM);
            parameters.Add("@NombreNotificador", datosRegistro.nombreNotificador);
            parameters.Add("@CelularNotificador", datosRegistro.celularNotificador);
          
            parameters.Add("@IdFarmacovigilancia",dbType: DbType.Int32,direction: ParameterDirection.Output);

            await connection.ExecuteAsync("[farm].[usp_Farmacovigilancia]",parameters,commandType: CommandType.StoredProcedure);

            // Obtener el valor OUTPUT
            return parameters.Get<int>("@IdFarmacovigilancia");
        }

    }
}
