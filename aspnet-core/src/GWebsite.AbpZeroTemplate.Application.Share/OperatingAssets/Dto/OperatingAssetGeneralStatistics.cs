using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.OperatingAssets.Dto
{
    public class OperatingAssetGeneralStatistics : Entity<int>
    {
        // SỐ LƯỢNG
        // Tổng số lượng tài sản
        public double PreviousQuantity { get; set; }
        public double CurrentQuantity { get; set; }
        public double QuantityRatio { get; set; }

        // Tổng số lượng tài sản đang ở trong kho
        public double PreviousInWareQuantity { get; set; }
        public double CurrentInWareQuantity { get; set; }
        public double InWareQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành nói chung
        public double PreviousInOperationQuantity { get; set; }
        public double CurrentInOperationQuantity { get; set; }
        public double InOperationQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành, có tính khấu hao nói chung
        public double PreviousInOperationDepreciatingQuantity { get; set; }
        public double CurrentInOperationDepreciatingQuantity { get; set; }
        public double InOperationDepreciatingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành, không tính khấu hao nói chung
        public double PreviousInOperationNotDepreciatingQuantity { get; set; }
        public double CurrentInOperationNotDepreciatingQuantity { get; set; }
        public double InOperationNotDepreciatingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành và được sử dụng
        public double PreviousInOperationAndUsingQuantity { get; set; }
        public double CurrentInOperationAndUsingQuantity { get; set; }
        public double InOperationAndUsingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành và được sử dụng, có tính khấu hao
        public double PreviousInOperationAndUsingDepreciatingQuantity { get; set; }
        public double CurrentInOperationAndUsingDepreciatingQuantity { get; set; }
        public double InOperationAndUsingDepreciatingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành và được sử dụng, không tính khấu hao
        public double PreviousInOperationAndUsingNotDepreciatingQuantity { get; set; }
        public double CurrentInOperationAndUsingNotDepreciatingQuantity { get; set; }
        public double InOperationAndUsingNotDepreciatingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng
        public double PreviousInOperationButNotUsingQuantity { get; set; }
        public double CurrentInOperationButNotUsingQuantity { get; set; }
        public double InOperationButNotUsingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
        public double PreviousInOperationButNotUsingDepreciatingQuantity { get; set; }
        public double CurrentInOperationButNotUsingDepreciatingQuantity { get; set; }
        public double InOperationButNotUsingDepreciatingQuantityRatio { get; set; }

        // Tổng số lượng tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
        public double PreviousInOperationButNotUsingNotDepreciatingQuantity { get; set; }
        public double CurrentInOperationButNotUsingNotDepreciatingQuantity { get; set; }
        public double InOperationButNotUsingNotDepreciatingQuantityRatio { get; set; }

        // GIÁ TRỊ
        // Tổng giá trị đã đầu tư
        public double PreviousAmount { get; set; }
        public double CurrentAmount { get; set; }
        public double AmountRatio { get; set; }

        // Tổng giá trị nguyên giá của tài sản nói chung
        public double PreviousOriginalAmount { get; set; }
        public double CurrentOriginalAmount { get; set; }
        public double OriginalAmountRatio { get; set; }

        // Tổng giá trị trích cho khấu hao
        public double PreviousDepreciatedAmount { get; set; }
        public double CurrentDepreciatedAmount { get; set; }
        public double DepreciatedAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang ở trong kho
        public double PreviousInWareOriginalAmount { get; set; }
        public double CurrentInWareOriginalAmount { get; set; }
        public double InWareOriginalAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành nói chung
        public double PreviousInOperationOriginalAmount { get; set; }
        public double CurrentInOperationOriginalAmount { get; set; }
        public double InOperationOriginalAmountRatio { get; set; }

        // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nói chung
        public double PreviousInOperationDepreciatingAmount { get; set; }
        public double CurrentInOperationDepreciatingAmount { get; set; }
        public double InOperationDepreciatingAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng
        public double PreviousInOperationAndUsingOriginalAmount { get; set; }
        public double CurrentInOperationAndUsingOriginalAmount { get; set; }
        public double InOperationAndUsingOriginalAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
        public double PreviousInOperationAndUsingDepreciatingOriginalAmount { get; set; }
        public double CurrentInOperationAndUsingDepreciatingOriginalAmount { get; set; }
        public double InOperationAndUsingDepreciatingOriginalAmountRatio { get; set; }

        // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành và được sử dụng, có tính khấu hao
        public double PreviousInOperationAndUsingDepreciatingAmount { get; set; }
        public double CurrentInOperationAndUsingDepreciatingAmount { get; set; }
        public double InOperationAndUsingDepreciatingAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành và được sử dụng, không tính khấu hao
        public double PreviousInOperationAndUsingNotDepreciatingOriginalAmount { get; set; }
        public double CurrentInOperationAndUsingNotDepreciatingOriginalAmount { get; set; }
        public double InOperationAndUsingNotDepreciatingOriginalAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng
        public double PreviousInOperationAndNotUsingOriginalAmount { get; set; }
        public double CurrentInOperationAndNotUsingOriginalAmount { get; set; }
        public double InOperationAndNotUsingOriginalAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
        public double PreviousInOperationAndNotUsingDepreciatingOriginalAmount { get; set; }
        public double CurrentInOperationAndNotUsingDepreciatingOriginalAmount { get; set; }
        public double InOperationAndNotUsingDepreciatingOriginalAmountRatio { get; set; }

        // Tổng giá trị trích cho khấu hao của các tài sản đang được vận hành nhưng không được sử dụng, có tính khấu hao
        public double PreviousInOperationAndNotUsingDepreciatingAmount { get; set; }
        public double CurrentInOperationAndNotUsingDepreciatingAmount { get; set; }
        public double InOperationAndNotUsingDepreciatingAmountRatio { get; set; }

        // Tổng giá trị nguyên giá của các tài sản đang được vận hành nhưng không được sử dụng, không tính khấu hao
        public double PreviousInOperationAndNotUsingNotDepreciatingOriginalAmount { get; set; }
        public double CurrentInOperationAndNotUsingNotDepreciatingOriginalAmount { get; set; }
        public double InOperationAndNotUsingNotDepreciatingOriginalAmountRatio { get; set; }
    }
}
