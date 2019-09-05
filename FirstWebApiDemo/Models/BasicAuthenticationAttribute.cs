using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FirstWebApiDemo.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private const string Realm = "My Realm";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Si l'entête d'autorisation est vide
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                //si la requete n'est pas autorisée, ajouter www-autenticate à l'entête de la requette dans le header pour indiquer que la requete necessite une authentification dans le header
                if(actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                //récupération du token dans le header de la requete
                String autificationToken = actionContext.Request.Headers.Authorization.Parameter;

                //décodage du contenu du token
                String decodeAuthorisationToken = Encoding.UTF8.GetString(Convert.FromBase64String(autificationToken));

                //Convertion de la chaine décodé dans un tableau de chaine de caractères
                String[] usernamePasswordArray = decodeAuthorisationToken.Split(':');

                //le premier element du tableau est le username
                string username = usernamePasswordArray[0];

                //le second élement est le mot de passe
                string password = usernamePasswordArray[1];

                //Appel de la fonction Login pour authentification de l'utilisateur

                if (UserValidate.Login(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;

                    if(HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
           // base.OnAuthorization(actionContext);
        }
    }
}