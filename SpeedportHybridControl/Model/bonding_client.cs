using System.Collections.Generic;

namespace SpeedportHybridControl.Model
{
    class bonding_client : SuperViewModel
    {
        private List<user_white_list> _user_white_list;
        private List<FLI> _FLI;
        private List<Routing_table> _Routing_table;
        private List<hybrid_show> _hybrid_show;

        public List<user_white_list> user_white_list
        {
            get { return _user_white_list; }
            set { SetProperty(ref _user_white_list, value); }
        }

        public List<FLI> FLI
        {
            get { return _FLI; }
            set { SetProperty(ref _FLI, value); }
        }

        public List<Routing_table> Routing_table
        {
            get { return _Routing_table; }
            set { SetProperty(ref _Routing_table, value); }
        }

        public List<hybrid_show> hybrid_show
        {
            get { return _hybrid_show; }
            set { SetProperty(ref _hybrid_show, value); }
        }
    }

    class user_white_list
    {
        public string s_id
        {
            get;
            set;
        }

        public string s_description
        {
            get;
            set;
        }

        public string s_type
        {
            get;
            set;
        }

        public string s_enable
        {
            get;
            set;
        }

        public string s_filterentry
        {
            get;
            set;
        }
    }

    class FLI
    {
        public string ID
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string enable
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public string filterEntry
        {
            get;
            set;
        }
    }

    class Routing_table
    {
        public string default_route
        {
            get;
            set;
        }
    }

    class hybrid_show
    {
        public string haap_addr
        {
            get;
            set;
        }

        public string t2v4_addr
        {
            get;
            set;
        }

        public string t2v6_addr
        {
            get;
            set;
        }

        public string t3v4_addr
        {
            get;
            set;
        }

        public string t3v6_addr
        {
            get;
            set;
        }

        public string tunnel_addr
        {
            get;
            set;
        }

        public string bras_pre
        {
            get;
            set;
        }

        public string haap_pre
        {
            get;
            set;
        }

        public string curpre_type
        {
            get;
            set;
        }

        public string check_hello
        {
            get;
            set;
        }

        public string hybrid_cin
        {
            get;
            set;
        }

        public string hybrid_idle_time
        {
            get;
            set;
        }

        public string hybrid_sessionid
        {
            get;
            set;
        }

        public string hybrid_magicnum
        {
            get;
            set;
        }

        public string hybrid_error_code
        {
            get;
            set;
        }

        public string dsl_state
        {
            get;
            set;
        }

        public string dsl_timeoutcnt
        {
            get;
            set;
        }

        public string dsl_intf
        {
            get;
            set;
        }

        public string dsl_local_addr
        {
            get;
            set;
        }

        public string dsl_remote_addr
        {
            get;
            set;
        }

        public string dsl_uploadbw
        {
            get;
            set;
        }

        public string dsl_downloadbw
        {
            get;
            set;
        }

        public string lte_state
        {
            get;
            set;
        }

        public string lte_timeoutcnt
        {
            get;
            set;
        }

        public string lte_intf
        {
            get;
            set;
        }

        public string lte_local_addr
        {
            get;
            set;
        }

        public string lte_remote_addr
        {
            get;
            set;
        }

        public string rtt_mode
        {
            get;
            set;
        }

        public string rtt_threshold
        {
            get;
            set;
        }

        public string rtt_violationtime
        {
            get;
            set;
        }

        public string rtt_compliancetime
        {
            get;
            set;
        }

        public string rtt_dsl
        {
            get;
            set;
        }

        public string rtt_lte
        {
            get;
            set;
        }

        public string rtt_diff
        {
            get;
            set;
        }

        public string bypass_up_bw
        {
            get;
            set;
        }

        public string bypass_dw_bw
        {
            get;
            set;
        }

        public string bypass_up_rb
        {
            get;
            set;
        }

        public string bypass_dw_rb
        {
            get;
            set;
        }

        public string bypass_up_record
        {
            get;
            set;
        }

        public string bypass_dw_record
        {
            get;
            set;
        }

        public string bypass_check
        {
            get;
            set;
        }
    }
}
