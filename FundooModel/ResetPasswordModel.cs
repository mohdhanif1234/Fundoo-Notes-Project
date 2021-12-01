// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="KPMG">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohammad Hanif"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// This is a ResetPasswordModel class
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the object named Email of the ResetPasswordModel class
        /// </summary>
        [Required] 
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the object named NewPassword of the ResetPasswordModel class
        /// </summary>
        [Required]
        public string NewPassword { get; set; }
    }
}
