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
using System.Collections.Generic;
using RDFSharp.Model;
using RDFSharp.Store;
using RDFSharp.Query;

namespace RDFSharp.Semantics
{

    /// <summary>
    /// RDFOntology represents an ontology definition.
    /// </summary>
    public class RDFOntology: RDFOntologyResource {

        #region Properties
        /// <summary>
        /// Model (T-BOX) of the ontology
        /// </summary>
        public RDFOntologyModel Model { get; internal set; }

        /// <summary>
        /// Data (A-BOX) of the ontology
        /// </summary>
        public RDFOntologyData Data { get; internal set; }

        /// <summary>
        /// Annotations describing the ontology
        /// </summary>
        public RDFOntologyAnnotationsMetadata Annotations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology with the given name
        /// </summary>
        public RDFOntology(RDFResource ontologyName) {
            if (ontologyName        != null) {
                this.Value           = ontologyName;
                this.PatternMemberID = ontologyName.PatternMemberID;
                this.Model           = new RDFOntologyModel();
                this.Data            = new RDFOntologyData();
                this.Annotations     = new RDFOntologyAnnotationsMetadata();
            }
            else {
                throw new RDFSemanticsException("Cannot create RDFOntology because given \"ontologyName\" parameter is null.");
            }
        }
        #endregion

        #region Methods

        #region Add
        /// <summary>
        /// Adds the "ontology -> owl:VersionInfo -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddVersionInfoAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.VersionInfo.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:VersionIRI -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddVersionIRIAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.VersionIRI.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:comment -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddCommentAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Comment.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:label -> ontologyLiteral" annotation to the ontology
        /// </summary>
        public RDFOntology AddLabelAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Label.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:seeAlso -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddSeeAlsoAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.SeeAlso.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> rdfs:isDefinedBy -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddIsDefinedByAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.IsDefinedBy.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:priorVersion -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddPriorVersionAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.PriorVersion.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:backwardCompatibleWith -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddBackwardCompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.BackwardCompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:incompatibleWith -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddIncompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.IncompatibleWith.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> owl:imports -> ontology" annotation to the ontology
        /// </summary>
        public RDFOntology AddImportsAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.Imports.AddEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Adds the "ontology -> ontologyAnnotationProperty -> ontologyResource" annotation to the ontology
        /// </summary>
        public RDFOntology AddCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty, RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.AddVersionInfoAnnotation((RDFOntologyLiteral)ontologyResource);
                    }
                }

                //owl:versionIRI
                else if (ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))) {
                     if (ontologyResource.IsOntology()) {
                         this.AddVersionIRIAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddCommentAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.AddLabelAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.AddSeeAlsoAnnotation(ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.AddIsDefinedByAnnotation(ontologyResource);
                }

                //owl:imports
                else if (ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))) {
                     if (ontologyResource.IsOntology()) {
                         this.AddImportsAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddBackwardCompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddIncompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.AddPriorVersionAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //custom
                else {
                    this.Annotations.CustomAnnotations.AddEntry(new RDFOntologyTaxonomyEntry(this, ontologyAnnotationProperty, ontologyResource));
                }
                
            }
            return this;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the "ontology -> owl:VersionInfo -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveVersionInfoAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.VersionInfo.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:VersionIRI -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveVersionIRIAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.VersionIRI.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:comment -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveCommentAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Comment.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:label -> ontologyLiteral" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveLabelAnnotation(RDFOntologyLiteral ontologyLiteral) {
            if (ontologyLiteral != null) {
                this.Annotations.Label.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()), ontologyLiteral));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:seeAlso -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveSeeAlsoAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.SeeAlso.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> rdfs:isDefinedBy -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveIsDefinedByAnnotation(RDFOntologyResource ontologyResource) {
            if (ontologyResource != null) {
                this.Annotations.IsDefinedBy.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()), ontologyResource));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:priorVersion -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemovePriorVersionAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.PriorVersion.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:backwardCompatibleWith -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveBackwardCompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.BackwardCompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:incompatibleWith -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveIncompatibleWithAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.IncompatibleWith.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> owl:imports -> ontology" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveImportsAnnotation(RDFOntology ontology) {
            if (ontology != null) {
                this.Annotations.Imports.RemoveEntry(new RDFOntologyTaxonomyEntry(this, RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()), ontology));
            }
            return this;
        }

        /// <summary>
        /// Removes the "ontology -> ontologyAnnotationProperty -> ontologyResource" annotation from the ontology
        /// </summary>
        public RDFOntology RemoveCustomAnnotation(RDFOntologyAnnotationProperty ontologyAnnotationProperty, RDFOntologyResource ontologyResource) {
            if (ontologyAnnotationProperty != null && ontologyResource != null) {

                //owl:versionInfo
                if (ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_INFO.ToString()))) {
                    if (ontologyResource.IsLiteral()) {
                        this.RemoveVersionInfoAnnotation((RDFOntologyLiteral)ontologyResource);
                    }
                }

                //owl:versionIRI
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.VERSION_IRI.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveVersionIRIAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //rdfs:comment
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.COMMENT.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveCommentAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:label
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.LABEL.ToString()))) {
                     if(ontologyResource.IsLiteral()) {
                        this.RemoveLabelAnnotation((RDFOntologyLiteral)ontologyResource);
                     }
                }

                //rdfs:seeAlso
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.SEE_ALSO.ToString()))) {
                     this.RemoveSeeAlsoAnnotation(ontologyResource);
                }

                //rdfs:isDefinedBy
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.RDFS.IS_DEFINED_BY.ToString()))) {
                     this.RemoveIsDefinedByAnnotation(ontologyResource);
                }

                //owl:imports
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.IMPORTS.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveImportsAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:backwardCompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.BACKWARD_COMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveBackwardCompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:incompatibleWith
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.INCOMPATIBLE_WITH.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemoveIncompatibleWithAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //owl:priorVersion
                else if(ontologyAnnotationProperty.Equals(RDFBASEOntology.SelectProperty(RDFVocabulary.OWL.PRIOR_VERSION.ToString()))) {
                     if(ontologyResource.IsOntology()) {
                        this.RemovePriorVersionAnnotation((RDFOntology)ontologyResource);
                     }
                }

                //custom
                else {
                     this.Annotations.CustomAnnotations.RemoveEntry(new RDFOntologyTaxonomyEntry(this, ontologyAnnotationProperty, ontologyResource));
                }

            }
            return this;
        }
        #endregion

        #region Set
        /// <summary>
        /// Builds a new intersection ontology from this ontology and a given one
        /// </summary>
        public RDFOntology IntersectWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.Namespace));
            if (ontology     != null) {

                //Intersect the models
                result.Model  = this.Model.IntersectWith(ontology.Model);

                //Intersect the datas
                result.Data   = this.Data.IntersectWith(ontology.Data);

                //Intersect the annotations            
                result.Annotations.VersionInfo            = this.Annotations.VersionInfo.IntersectWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = this.Annotations.VersionIRI.IntersectWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = this.Annotations.Comment.IntersectWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = this.Annotations.Label.IntersectWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = this.Annotations.SeeAlso.IntersectWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = this.Annotations.IsDefinedBy.IntersectWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = this.Annotations.PriorVersion.IntersectWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = this.Annotations.BackwardCompatibleWith.IntersectWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = this.Annotations.IncompatibleWith.IntersectWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = this.Annotations.Imports.IntersectWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = this.Annotations.CustomAnnotations.IntersectWith(ontology.Annotations.CustomAnnotations);
            }

            return result;
        }

        /// <summary>
        /// Builds a new union ontology from this ontology and a given one
        /// </summary>
        public RDFOntology UnionWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.Namespace));

            //Use this model
            result.Model      = result.Model.UnionWith(this.Model);

            //Use this data
            result.Data       = result.Data.UnionWith(this.Data);

            //Use this annotations
            result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(this.Annotations.VersionIRI);
            result.Annotations.Comment                = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label                  = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(this.Annotations.PriorVersion);
            result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(this.Annotations.BackwardCompatibleWith);
            result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(this.Annotations.IncompatibleWith);
            result.Annotations.Imports                = result.Annotations.Imports.UnionWith(this.Annotations.Imports);
            result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given ontology
            if (ontology     != null) {

                //Union the model
                result.Model  = result.Model.UnionWith(ontology.Model);

                //Union the data
                result.Data   = result.Data.UnionWith(ontology.Data);

                //Union the annotations
                result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = result.Annotations.Comment.UnionWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = result.Annotations.Label.UnionWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = result.Annotations.Imports.UnionWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(ontology.Annotations.CustomAnnotations);

            }
            return result;
        }

        /// <summary>
        /// Builds a new difference ontology from this ontology and a given one
        /// </summary>
        public RDFOntology DifferenceWith(RDFOntology ontology) {
            var result        = new RDFOntology(new RDFResource(RDFNamespaceRegister.DefaultNamespace.Namespace));

            //Use this model
            result.Model      = result.Model.UnionWith(this.Model);

            //Use this data
            result.Data       = result.Data.UnionWith(this.Data);

            //Use this annotations
            result.Annotations.VersionInfo            = result.Annotations.VersionInfo.UnionWith(this.Annotations.VersionInfo);
            result.Annotations.VersionIRI             = result.Annotations.VersionIRI.UnionWith(this.Annotations.VersionIRI);
            result.Annotations.Comment                = result.Annotations.Comment.UnionWith(this.Annotations.Comment);
            result.Annotations.Label                  = result.Annotations.Label.UnionWith(this.Annotations.Label);
            result.Annotations.SeeAlso                = result.Annotations.SeeAlso.UnionWith(this.Annotations.SeeAlso);
            result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.UnionWith(this.Annotations.IsDefinedBy);
            result.Annotations.PriorVersion           = result.Annotations.PriorVersion.UnionWith(this.Annotations.PriorVersion);
            result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.UnionWith(this.Annotations.BackwardCompatibleWith);
            result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.UnionWith(this.Annotations.IncompatibleWith);
            result.Annotations.Imports                = result.Annotations.Imports.UnionWith(this.Annotations.Imports);
            result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.UnionWith(this.Annotations.CustomAnnotations);

            //Manage the given ontology
            if (ontology     != null) {

                //Difference the model
                result.Model  = result.Model.DifferenceWith(ontology.Model);

                //Difference the data
                result.Data   = result.Data.DifferenceWith(ontology.Data);

                //Difference the annotations
                result.Annotations.VersionInfo            = result.Annotations.VersionInfo.DifferenceWith(ontology.Annotations.VersionInfo);
                result.Annotations.VersionIRI             = result.Annotations.VersionIRI.DifferenceWith(ontology.Annotations.VersionIRI);
                result.Annotations.Comment                = result.Annotations.Comment.DifferenceWith(ontology.Annotations.Comment);
                result.Annotations.Label                  = result.Annotations.Label.DifferenceWith(ontology.Annotations.Label);
                result.Annotations.SeeAlso                = result.Annotations.SeeAlso.DifferenceWith(ontology.Annotations.SeeAlso);
                result.Annotations.IsDefinedBy            = result.Annotations.IsDefinedBy.DifferenceWith(ontology.Annotations.IsDefinedBy);
                result.Annotations.PriorVersion           = result.Annotations.PriorVersion.DifferenceWith(ontology.Annotations.PriorVersion);
                result.Annotations.BackwardCompatibleWith = result.Annotations.BackwardCompatibleWith.DifferenceWith(ontology.Annotations.BackwardCompatibleWith);
                result.Annotations.IncompatibleWith       = result.Annotations.IncompatibleWith.DifferenceWith(ontology.Annotations.IncompatibleWith);
                result.Annotations.Imports                = result.Annotations.Imports.DifferenceWith(ontology.Annotations.Imports);
                result.Annotations.CustomAnnotations      = result.Annotations.CustomAnnotations.DifferenceWith(ontology.Annotations.CustomAnnotations);

            }
            return result;
        }
        #endregion

        #region Convert
        /// <summary>
        /// Gets an ontology representation of the given graph.
        /// </summary>
        public static RDFOntology FromRDFGraph(RDFGraph ontGraph) {
            return RDFSemanticsUtilities.FromRDFGraph(ontGraph);
        }

        /// <summary>
        /// Gets a graph representation of this ontology, eventually including inferences
        /// </summary>
        public RDFGraph ToRDFGraph(Boolean includeInferences) {
            return RDFSemanticsUtilities.ToRDFGraph(this, includeInferences);
        }
        #endregion

        #region Validate
        /// <summary>
        /// Validate this ontology against a set of RDFS/OWL-DL rules, detecting errors and inconsistencies affecting its model and data.
        /// </summary>
        public RDFOntologyValidationReport Validate() { 
            return (new RDFOntologyValidator()).AnalyzeOntology(this);
        }
        #endregion

        #endregion

    }

    /// <summary>
    /// RDFOntologyAnnotationsMetadata represents a collector for annotations describing resources of an ontology.
    /// </summary>
    public class RDFOntologyAnnotationsMetadata {

        #region Properties
        /// <summary>
        /// "owl:versionInfo" annotations
        /// </summary>
        public RDFOntologyTaxonomy VersionInfo { get; internal set; }

        /// <summary>
        /// "owl:versionIRI" annotations
        /// </summary>
        public RDFOntologyTaxonomy VersionIRI { get; internal set; }

        /// <summary>
        /// "rdfs:comment" annotations
        /// </summary>
        public RDFOntologyTaxonomy Comment { get; internal set; }

        /// <summary>
        /// "rdfs:label" annotations
        /// </summary>
        public RDFOntologyTaxonomy Label { get; internal set; }

        /// <summary>
        /// "rdfs:seeAlso" annotations
        /// </summary>
        public RDFOntologyTaxonomy SeeAlso { get; internal set; }

        /// <summary>
        /// "rdfs:isDefinedBy" annotations
        /// </summary>
        public RDFOntologyTaxonomy IsDefinedBy { get; internal set; }

        /// <summary>
        /// "owl:priorVersion" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy PriorVersion { get; internal set; }

        /// <summary>
        /// "owl:BackwardCompatibleWith" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy BackwardCompatibleWith { get; internal set; }

        /// <summary>
        /// "owl:IncompatibleWith" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy IncompatibleWith { get; internal set; }

        /// <summary>
        /// "owl:imports" annotations (specific for ontologies)
        /// </summary>
        public RDFOntologyTaxonomy Imports { get; internal set; }

        /// <summary>
        /// Custom-property annotations
        /// </summary>
        public RDFOntologyTaxonomy CustomAnnotations { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an empty ontology annotations metadata
        /// </summary>
        internal RDFOntologyAnnotationsMetadata() {
            this.VersionInfo            = new RDFOntologyTaxonomy();
            this.VersionIRI             = new RDFOntologyTaxonomy();
            this.Comment                = new RDFOntologyTaxonomy();
            this.Label                  = new RDFOntologyTaxonomy();
            this.SeeAlso                = new RDFOntologyTaxonomy();
            this.IsDefinedBy            = new RDFOntologyTaxonomy();
            this.PriorVersion           = new RDFOntologyTaxonomy();
            this.BackwardCompatibleWith = new RDFOntologyTaxonomy();
            this.IncompatibleWith       = new RDFOntologyTaxonomy();
            this.Imports                = new RDFOntologyTaxonomy();
            this.CustomAnnotations      = new RDFOntologyTaxonomy();
        }
        #endregion

    }

}