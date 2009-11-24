using System;
using System.Collections;

using Context = System.Web.HttpContext;

namespace Questionnaire.Models
{
    public class Question : Entity
    {
        #region Methods

        public static EntityCollection FetchAll ( )
        {
            EntityCollection result = 
                Context.Current.Session[ "CachedQuestions" ] 
                    as EntityCollection;

            if ( result == null )
            {
                result = new EntityCollection ( );

                string[] dataRows = 
                    DataStore.Fetch ( ).Split ( new char[] { '\n', '\r' } );
                foreach ( string dataRow in dataRows )
                {
                    if ( !string.IsNullOrEmpty ( dataRow ) )
                    {
                        string[] dataColumns = 
                            dataRow.Substring (
                                ( dataRow.IndexOf ( ',' ) + 1 ) ).Split ( ',' );
                        Question question = new Question ( );
                        try
                        {
                            question.Answers = new EntityCollection ( );
                            question.Id = Guid.NewGuid ( ).ToString ( "N" );
                            question.Value = 
                                dataRow.Substring ( 0, ( dataRow.IndexOf ( ',' ) ) );
                            foreach ( string dataColumn in dataColumns )
                            {
                                if ( !string.IsNullOrEmpty ( dataColumn ) )
                                {
                                    Answer answer = new Answer ( );
                                    answer.Id = Guid.NewGuid ( ).ToString ( "N" );
                                    answer.Value = 
                                        dataColumn.Replace ( "*", string.Empty );
                                    if ( dataColumn.IndexOf ( '*' ) > -1 )
                                    {
                                        question.CorrectAnswerId = answer.Id;
                                    }
                                    question.Answers.Add ( answer );
                                }
                            }
                        }
                        catch
                        {
                            throw new Exception ( "The application could not retrieve the questions." );
                        }
                        result.Add ( question );
                    }
                }

                Context.Current.Session[ "CachedQuestions" ] = result;
            }

            return result;
        }

        public static EntityCollection FetchRandom ( )
        {
            EntityCollection result = 
                Context.Current.Session[ "CachedRandomQuestions" ]
                    as EntityCollection;

            if ( result == null )
            {
                result = new EntityCollection ( );

                EntityCollection entityCollection = new EntityCollection ( );
                foreach ( Entity entity in FetchAll ( ) )
                {
                    entityCollection.Add ( entity );
                }
                int numberOfEntities = Configuration.NumberOfQuestionsToDisplay;
                Random random = new Random ( );
                for ( int index = 0; index < numberOfEntities; ++index )
                {
                    int randomIndex = random.Next ( numberOfEntities );
                    result.Add ( entityCollection[ randomIndex ] );
                    entityCollection.RemoveAt ( randomIndex );
                }

                Context.Current.Session[ "CachedRandomQuestions" ] = result;
            }

            return result;
        }

        public static bool IsCorrect ( 
            string answerId, 
            string questionId )
        {
            bool result = false;

            foreach ( Question question in FetchAll ( ) )
            {
                if ( question.Id == questionId )
                {
                    if ( question.CorrectAnswerId == answerId )
                    {
                        result = true;
                    }
                    break;
                }
            }

            return result;
        }

        #endregion

        #region Properties

        public EntityCollection Answers
        {
            get;
            set;
        }

        public string CorrectAnswerId
        {
            get;
            set;
        }

        public string SubmittedAnswerId
        {
            get;
            set;
        }

        #endregion
    }
}