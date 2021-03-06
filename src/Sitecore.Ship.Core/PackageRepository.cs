﻿using System.Collections.Generic;
using System.Linq;
using Sitecore.Ship.Core.Contracts;
using Sitecore.Ship.Core.Domain;

namespace Sitecore.Ship.Core
{
    public class PackageRepository : IPackageRepository
    {
        private readonly IPackageRunner _packageRunner;

        public PackageRepository(
            IPackageRunner packageRunner
            )
        {
            _packageRunner = packageRunner;
        }

        public PackageManifest AddPackage(InstallPackage package)
        {
            var manifest = _packageRunner.Execute(package.Path, package.DisableIndexing);

        

            return manifest;
        }

        public IEnumerable<PackageManifest> AddPackages(InstallPackages packages)
        {
            var manifests = _packageRunner.Execute(packages.Paths, packages.DisableIndexing);

           
            return manifests;
        }
    }
}