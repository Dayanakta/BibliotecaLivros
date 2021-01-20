using System;


namespace BibliotecaLivros.Domain.Models
{
    public class Bookshelf
    {
        #region Dados Estante
        /// <summary>
        /// Tipo de recurso para metadados de estante.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// ID desta estante.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Título desta estante.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição desta estante.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Se esta estante é PÚBLICA ou PRIVADA.
        /// </summary>
        public string Access { get; set; }

        /// <summary>
        /// Hora da última modificação desta estante (timestamp UTC formatado com resolução de milissegundos).	
        /// </summary>
        public DateTime Update { get; set; }

        /// <summary>
        /// Hora criação da estante (timestamp UTC formatado com resolução em milissegundos).	
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Número de volumes nesta estante.
        /// </summary>
        public int VolumeCount { get; set; }

        /// <summary>
        /// A última vez que um volume foi adicionado ou removido desta estante (carimbo de data / hora UTC formatado com resolução de milissegundos).	
        /// </summary>
        public DateTime VolumesLastUpdated { get; set; }

        /// <summary>
        /// URL para este recurso.
        /// </summary>
        public string SelfLink { get; set; }
        #endregion

        #region Construtores
        public Bookshelf()
        {

        }
        #endregion
    }
}

