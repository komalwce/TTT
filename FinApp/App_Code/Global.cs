using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Contains my site's global variables.
/// </summary>
public static class Global
{
        static string _siteLogo = "images/logo.png";
        static string _siteAltLogo = "images/logo.png";
        static string _siteName = "FinLearn";
        static string _siteTagline = "Our Tagline Goes Here.";
        static string _siteContact = "+91 94 03 575 061";
        static string _siteContact2 = "+91 91 75 120 624";
        static string _siteOwner = "The Think Tank";
        static string _siteAddress = "Walchand College of Engineering, Sangli, MH-IN - 416415";
        static string _siteEmail = "contact@finlearn.org";
        static string _encryptionKey = "WEOJFDH123123H3";
        static string _currency = "&#8377";
        static string _siteFB = "#";
        static string _siteInsta = "#";
        static string _siteTwitter = "#";
        static string _siteGPlus = "#";
        static string _siteLinkedIn = "#";
        static string _newsapikey = "ae123aae8fb4482d9a5c0ae999c14e49";
        static string _shareapikey = "-ya2sqK7xxbRbbBekB-f";
    public static string SiteLogo
    {
        get
        {
            return _siteLogo;
        }
        set
        {
            _siteLogo = value;
        }
    }
    public static string SiteAltLogo
    {
        get
        {
            return _siteAltLogo;
        }
        set
        {
            _siteAltLogo = value;
        }
    }
    public static string SiteName
    {
        get
        {
            return _siteName;
        }
        set
        {
            _siteName = value;
        }
    }
    public static string SiteTagline
    {
        get
        {
            return _siteTagline;
        }
        set
        {
            _siteTagline = value;
        }
    }
    public static string SiteContact
    {
        get
        {
            return _siteContact;
        }
        set
        {
            _siteContact = value;
        }
    }
    public static string SiteContact2
    {
        get
        {
            return _siteContact2;
        }
        set
        {
            _siteContact2 = value;
        }
    }
    public static string SiteOwner
    {
        get
        {
            return _siteOwner;
        }
        set
        {
            _siteOwner = value;
        }
    }
    public static string SiteAddress
    {
        get
        {
            return _siteAddress;
        }
        set
        {
            _siteAddress = value;
        }
    }
    public static string EncryptionKey
    {
        get
        {
            return _encryptionKey;
        }
        set
        {
            _encryptionKey = value;
        }
    }
    public static string SiteEmail
    {
        get
        {
            return _siteEmail;
        }
        set
        {
            _siteEmail = value;
        }
    }
    public static string Currency
    {
        get
        {
            return _currency;
        }
        set
        {
            _currency = value;
        }
    }
    public static string SiteFB
    {
        get
        {
            return _siteFB;
        }
        set
        {
            _siteFB = value;
        }
    }
    public static string SiteInsta
    {
        get
        {
            return _siteInsta;
        }
        set
        {
            _siteInsta = value;
        }
    }
    public static string SiteGPlus
    {
        get
        {
            return _siteGPlus;
        }
        set
        {
            _siteGPlus = value;
        }
    }
    public static string SiteTwitter
    {
        get
        {
            return _siteTwitter;
        }
        set
        {
            _siteTwitter = value;
        }
    }
    public static string SiteLinkedIn
    {
        get
        {
            return _siteLinkedIn;
        }
        set
        {
            _siteLinkedIn = value;
        }
    }
    public static string NewsAPIKey
    {
        get
        {
            return _newsapikey;
        }
        set
        {
            _newsapikey = value;
        }
    }
    public static string ShareAPIKey
    {
        get
        {
            return _shareapikey;
        }
        set
        {
            _shareapikey = value;
        }
    }


}

