namespace BibliotecaLivros.Domain.Models
{
    public class Book
    {
        #region Dados Books
        /// <summary>
        /// Identificador único para um volume
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Título do volume.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Legenda do volume.
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// Os nomes dos autores e / ou editores deste volume.
        /// </summary>
        ///   /// <summary>
        /// Uma sinopse do volume.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Link da imagem.
        /// </summary>
        public string ImageLinks { get; set; }

        /// <summary>
        /// Indica se o livro está como favorito.
        /// </summary>
        public bool IsFavorite { get; set; }

        #endregion
    }
}