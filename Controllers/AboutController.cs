using Microsoft.AspNetCore.Mvc;

namespace HariFood.Controllers {

    [Route ("harifood/[controller]/[action]")]
    public class AboutController {

        public string Phone () => "078247929384";
        public string Address () => "Leeds UK";
        
    }
}