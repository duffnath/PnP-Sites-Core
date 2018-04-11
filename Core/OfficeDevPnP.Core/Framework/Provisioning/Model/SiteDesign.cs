﻿using OfficeDevPnP.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.Core.Framework.Provisioning.Model
{
    public partial class SiteDesign: BaseModel, IEquatable<SiteDesign>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Title for the SiteDesign
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description flag for the SiteDesign
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the IsDefault for the SiteDesign
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the WebTemplate flag for the SiteDesign
        /// </summary>
        public SiteDesignWebTemplate WebTemplate { get; set; }

        /// <summary>
        /// Gets or sets the PreviewImageUrl flag for the SiteDesign
        /// </summary>
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the PreviewImageAltText flag for the SiteDesign
        /// </summary>
        public string PreviewImageAltText { get; set; }

        /// <summary>
        /// Gets or sets the list of SiteScripts for the SiteDesign
        /// </summary>
        public List<string> SiteScripts { get; set; } = new List<string>();

        #endregion

        #region Comparison code
        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Returns HashCode</returns>
        public override int GetHashCode()
        {
            return (String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|",
                (this.Title != null ? this.Title.GetHashCode() : 0),
                (this.Description != null ? this.Description.GetHashCode() : 0),
                this.IsDefault.GetHashCode(),
                this.WebTemplate.GetHashCode(),
                (this.PreviewImageUrl != null ? this.PreviewImageUrl.GetHashCode() : 0),
                (this.PreviewImageAltText != null ? this.PreviewImageAltText.GetHashCode() : 0),
                this.SiteScripts.Aggregate(0, (acc, next) => acc += (next != null ? next.GetHashCode() : 0))
            ).GetHashCode());
        }

        /// <summary>
        /// Compares object with SiteDesign
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>true if the current object is equal to the SiteDesign</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is SiteDesign))
            {
                return (false);
            }
            return (Equals((SiteDesign)obj));
        }

        /// <summary>
        /// Compares SiteDesign object based on Title, Description, IsDefault, WebTemplate, PreviewImageUrl, and PreviewImageAltText properties.
        /// </summary>
        /// <param name="other">SiteDesign object</param>
        /// <returns>true if the SiteDesign object is equal to the current object; otherwise, false.</returns>
        public bool Equals(SiteDesign other)
        {
            if (other == null)
            {
                return (false);
            }

            return (this.Title == other.Title &&
                this.Description == other.Description &&
                this.IsDefault == other.IsDefault &&
                this.WebTemplate == other.WebTemplate &&
                this.PreviewImageUrl == other.PreviewImageUrl &&
                this.PreviewImageAltText == other.PreviewImageAltText &&
                this.SiteScripts.DeepEquals(other.SiteScripts)
                );
        }

        #endregion
    }

    /// <summary>
    /// WebTemplate IDs for Site Designs
    /// </summary>
    public enum SiteDesignWebTemplate
    {
        /// <summary>
        /// WebTemplate ID for a "modern" Team Site
        /// </summary>
        TeamSite = 64,
        /// <summary>
        /// WebTemplate ID for a "modern" Communication Site
        /// </summary>
        CommunicationSite = 68,
    }
}
