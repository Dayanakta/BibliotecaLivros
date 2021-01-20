namespace BibliotecaLivros.Domain.Models
{
    public class ImageLinks
    {
        #region Links diversos tamanhos de imagem
        /// <summary>
        /// Link da imagem para o tamanho da miniatura(largura de ~ 128 pixels).
        /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
        /// Link de imagem para tamanho pequeno(largura de aproximadamente 300 pixels).
        /// </summary>
        public string Small { get; set; }
        /// <summary>
        /// Link de imagem para tamanho médio(largura de ~ 575 pixels).
        /// </summary>
        public string Medium { get; set; }
        /// <summary>
        /// Link da imagem para tamanho grande(largura de ~ 800 pixels).
        /// </summary>
        public string Large { get; set; }
        /// <summary>
        /// Link da imagem para miniaturas pequenas(largura de aproximadamente 80 pixels).
        /// </summary>
        public string SmallThumbnail { get; set; }
        /// <summary>
        /// Link da imagem para tamanho extra grande(largura de ~ 1280 pixels).
        /// </summary>
        public string ExtraLarge { get; set; }

        #endregion
        #region Construtores
        public ImageLinks()
        {

        }
        #endregion
    }
}
