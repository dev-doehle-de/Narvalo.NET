﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Build
{
    using System;
    using System.Net;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    /// <summary>
    /// MSBuild task to download a resource from a specified URI to a local file.
    /// </summary>
    /// <example>
    /// Download latest version of NuGet:
    /// <code>
    /// <![CDATA[
    /// <DownloadFile Address="https://nuget.org/nuget.exe" 
    ///               OutputFile="$(SolutionDir)\tools\nuget.exe" />
    /// ]]>
    /// </code>
    /// </example>
    public sealed class DownloadFile : Task
    {
        /// <summary>
        /// Gets or sets the URI from which to download data.
        /// </summary>
        /// <value>The URI from which to download data.</value>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the local file that is to receive the data.
        /// </summary>
        /// <value>The name of the local file that is to receive the data.</value>
        [Required]
        public string OutputFile { get; set; }

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <returns><see langword="true"/> if the task successfully executed; otherwise, 
        /// <see langword="false"/>.</returns>
        public override bool Execute()
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(Address, OutputFile);
                }
            }
            catch (ArgumentNullException ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
            catch (NotSupportedException ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
            catch (WebException ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }

            return !Log.HasLoggedErrors;
        }
    }
}
