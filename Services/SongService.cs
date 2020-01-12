using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1809E_UWP_DAPI.Models;

namespace T1809E_UWP_DAPI.Services
{
    public class SongService
    {
        public ObservableCollection<Song> LoadSong()
        {
            ObservableCollection<Song> list = new ObservableCollection<Song>();
            list.Add(new Song()
            {
                SongName = "Đi về phía thinh lặng",
                Link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/DiVePhiaThinhLang-BuiAnhTuanOrange-5717183.mp3",
                Views = 12513,
                Description = "Bùi Anh Tuấn - Dọng hát hay khủng khiếp",
                Thumbnail = "https://i.ytimg.com/vi/Xs5TbbFQuDw/maxresdefault.jpg"
            });
            list.Add(new Song()
            {
                SongName = "Liệu Giờ",
                Link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui987/LieuGio-2TVan-5943444.mp3",
                Views = 5245345,
                Description = "Liệu Giờ",
                Thumbnail = "https://v-phinf.pstatic.net/20190507_268/1557217554946lRNMD_JPEG/upload_Lieu%2Bgio_2T.jpg"
            });
            list.Add(new Song()
            {
                SongName = "Từng Yêu",
                Link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui983/TungYeu-PhanDuyAnh-5989256.mp3",
                Views = 43431200,
                Description = "Từng Yêu",
                Thumbnail = "https://i.ytimg.com/vi/pENMETTGamA/maxresdefault.jpg"
            });
            list.Add(new Song()
            {
                SongName = "Sáng Mắt Chưa",
                Link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui987/SangMatChua-TrucNhan-6042213.mp3",
                Views = 43431200,
                Description = "Sáng Mắt Chưa",
                Thumbnail = "https://nguoi-noi-tieng.com/images/post/tieu-su-ca-si-truc-nhan-370330.jpg"
            });
         
            return list;
        }
    }
}
