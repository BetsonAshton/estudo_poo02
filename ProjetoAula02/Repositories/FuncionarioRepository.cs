using Newtonsoft.Json;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe para gravação dos dados de funcionário em arquivos
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar dados do funcionário e arquivo Json
        /// </summary>
        public void ExportarJson(Funcionario funcionario)
        {

            // serializar os dados do funcionário em Json
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            using (var streamWriter = new StreamWriter($"C:\\temp\\funcionario_{funcionario.Id}.json"))
            {
                //escrever no arquivo
                streamWriter.WriteLine(json);
            }


        }
        /// <summary>
        /// Método para gravar dados do funcionário e arquivo Xml
        /// </summary>
        public void ExportarXml(Funcionario funcionario)
        {
            // Serializar os dados do funcionário para XML
            var xml = new XmlSerializer(typeof(Funcionario));

            // abrindo um arquivo gravar os arquivos
            using (var streamWriter = new StreamWriter($"C:\\temp\\funcionario_{funcionario.Id}.xml"))
            {
                xml.Serialize(streamWriter, funcionario);
            }
        }
    }
}
