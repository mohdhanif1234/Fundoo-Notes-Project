// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="KPMG">
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
    /// This is a RegisterModel class
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets the object named FirstName of the RegisterModel class
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the object named LastName of the RegisterModel class
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the object named Email of the RegisterModel class
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the object named Password of the RegisterModel class
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the object named UserId of the RegisterModel class. It's a primary key in the DB table
        /// </summary>
        [Key]
        public int UserId { get; set; }
    }
}
