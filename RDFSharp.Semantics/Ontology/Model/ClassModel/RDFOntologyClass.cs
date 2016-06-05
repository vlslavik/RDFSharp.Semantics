﻿/*
   Copyright 2012-2016 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using RDFSharp.Model;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntologyClass represents a class definition within an ontology model.
    /// </summary>
    public class RDFOntologyClass: RDFOntologyResource {

        #region Properties
        /// <summary>
        /// Flag indicating that this ontology class is "owl:DeprecatedClass"
        /// </summary>
        public Boolean Deprecated { get; internal set; }

        /// <summary>
        /// Type of ontology class (OWL/RDFS)
        /// </summary>
        public RDFSemanticsEnums.RDFOntologyClassType Type { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an ontology class with the given name and type=OWL
        /// </summary>
        public RDFOntologyClass(RDFResource className) {
            if (className != null) {
                this.Value           = className;
                this.Type            = RDFSemanticsEnums.RDFOntologyClassType.OWL;
                this.PatternMemberID = className.PatternMemberID;
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntologyClass because given \"className\" parameter is null.");
            }
        }

        /// <summary>
        /// Default-ctor to build an ontology class with the given name and type
        /// </summary>
        public RDFOntologyClass(RDFResource className, RDFSemanticsEnums.RDFOntologyClassType type): this(className) {
            this.Type = type;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets or unsets this ontology class as "owl:DeprecatedClass"
        /// </summary>
        public RDFOntologyClass SetDeprecated(Boolean deprecated) {
            if (!this.IsRestrictionClass() && !this.IsCompositeClass() && !this.IsDataRangeClass() && !this.IsEnumerateClass()) {
                 this.Deprecated = deprecated;
            }
            return this;
        }
        #endregion

    }

}