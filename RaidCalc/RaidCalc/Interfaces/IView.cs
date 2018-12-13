using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Interfaces
{
    public interface IView
    {
        /// <summary>
        /// 뷰가 연결될 컨트롤러
        /// </summary>
        IController Controller { get; set; }

        /// <summary>
        /// 뷰를 식별하기 위한 뷰의 이름.
        /// </summary>
        string ViewName { get; set; }

        /// <summary>
        /// 뷰가 연결될 컨트롤러를 지정합니다.
        /// </summary>
        /// <param name="controller">컨트롤러</param>
        void SetController(IController controller);

        /// <summary>
        /// 뷰에 데이터를 입력합니다.
        /// </summary>
        /// <param name="data">데이터 배열</param>
        void DrawData(object[] data);
    }
}
