using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AwesomeBlog.Models
{
    [MetadataType(typeof(blogstuufMetadata))]
    public partial class blogstuuf
    {
    }

    public class blogstuufMetadata
    {
        [Required(ErrorMessage = "Oi! Ye can't move on yet! I need this!")
        , Display(Name = "Title")]
        public string Title;

        [Required(ErrorMessage = "No go without a when, buddy.")
        , Display(Name = "Date Posted")]
        public DateTime DatePosted;

        [Required(ErrorMessage = "Gotta have yer name, friend.")
        , Display(Name = "Author")]
        public string PosterName;

        [Required(ErrorMessage = "Don't bother makin' if ya ain't gonna say nothin'!")
        , Display(Name = "Content")]
        public string Message;

        [Display(Name = "Post Pic")
        , MaxLength(200, ErrorMessage = "It's too long, mate!")]
        public string Image;

        [Display(Name = "Rating")]
        public int Rating;

        [Display(Name = "Views")]
        public int viewCount;

        [Display(Name = "Tassels")]
        public string tags;
    }
}