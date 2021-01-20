namespace BibliotecaLivros.Domain.Models
{
    public class Volume
    {
        #region Dados Volume
        /// <summary>
        /// Identificador único para um volume
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Tipo de recurso para um volume.
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Identificador opaco para uma versão específica de um recurso de volume.
        /// </summary>
        public string Etag { get; set; }
        /// <summary>
        /// URL para este recurso.
        /// </summary>
        public string SelfLink { get; set; }
        /// <summary>
        /// Informações gerais de volume.
        /// </summary>
        public VolumeInfo VolumeInfo { get; set; }
        #endregion

        #region Construtores
        public Volume()
        {

        }
        #endregion
    }
}
