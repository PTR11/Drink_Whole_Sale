﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkWholeSale.Persistence
{
    public class RegistrationViewModel : GuestViewModel
    {
        [Required(ErrorMessage = "A felhasználónév megadása kötelező.")]
        [RegularExpression("^[A-Za-z0-9_-]{5,40}$", ErrorMessage = "A felhasználónév formátuma, vagy hossza nem megfelelő.")]
        public String UserName { get; set; }

        /// <summary>
        /// Jelszó.
        /// </summary>
        [Required(ErrorMessage = "A jelszó megadása kötelező.")]
        [RegularExpression("^[A-Za-z0-9_-]{5,40}$", ErrorMessage = "A jelszó formátuma, vagy hossza nem megfelelő.")]
        [DataType(DataType.Password)]
        public String UserPassword { get; set; }

        /// <summary>
        /// Jelszó ismételt megadása.
        /// </summary>
        [Required(ErrorMessage = "A jelszó ismételt megadása kötelező.")]
        [Compare(nameof(UserPassword), ErrorMessage = "A két jelszó nem egyezik.")]
        [DataType(DataType.Password)]
        public String UserConfirmPassword { get; set; }
    }
}
