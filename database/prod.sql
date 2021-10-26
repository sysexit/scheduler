--
-- PostgreSQL database dump
--

-- Dumped from database version 14.0 (Debian 14.0-1.pgdg110+1)
-- Dumped by pg_dump version 14.0 (Debian 14.0-1.pgdg110+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: logins; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.logins (
    email character varying(255) NOT NULL,
    password character varying(60) NOT NULL,
    "group" integer DEFAULT 1,
    enabled boolean DEFAULT true NOT NULL
);


ALTER TABLE public.logins OWNER TO api;

--
-- Name: positions; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.positions (
    id integer NOT NULL,
    title character varying(10) NOT NULL
);


ALTER TABLE public.positions OWNER TO api;

--
-- Name: positions_id_seq; Type: SEQUENCE; Schema: public; Owner: api
--

CREATE SEQUENCE public.positions_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.positions_id_seq OWNER TO api;

--
-- Name: positions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: api
--

ALTER SEQUENCE public.positions_id_seq OWNED BY public.positions.id;


--
-- Name: schedule; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.schedule (
    id integer NOT NULL,
    user_id integer NOT NULL,
    start timestamp with time zone NOT NULL,
    "end" timestamp with time zone NOT NULL,
    position_id integer NOT NULL,
    published boolean DEFAULT false NOT NULL
);


ALTER TABLE public.schedule OWNER TO api;

--
-- Name: schedule_id_seq; Type: SEQUENCE; Schema: public; Owner: api
--

CREATE SEQUENCE public.schedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedule_id_seq OWNER TO api;

--
-- Name: schedule_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: api
--

ALTER SEQUENCE public.schedule_id_seq OWNED BY public.schedule.id;


--
-- Name: templates; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.templates (
    id integer NOT NULL,
    start character(5) NOT NULL,
    "end" character(5) NOT NULL,
    position_id integer NOT NULL
);


ALTER TABLE public.templates OWNER TO api;

--
-- Name: templates_id_seq; Type: SEQUENCE; Schema: public; Owner: api
--

CREATE SEQUENCE public.templates_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.templates_id_seq OWNER TO api;

--
-- Name: templates_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: api
--

ALTER SEQUENCE public.templates_id_seq OWNED BY public.templates.id;


--
-- Name: timesheets; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.timesheets (
    id integer NOT NULL,
    schedule_id integer,
    user_id integer NOT NULL,
    start timestamp with time zone NOT NULL,
    "end" timestamp with time zone NOT NULL
);


ALTER TABLE public.timesheets OWNER TO api;

--
-- Name: timesheets_id_seq; Type: SEQUENCE; Schema: public; Owner: api
--

CREATE SEQUENCE public.timesheets_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.timesheets_id_seq OWNER TO api;

--
-- Name: timesheets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: api
--

ALTER SEQUENCE public.timesheets_id_seq OWNED BY public.timesheets.id;


--
-- Name: tokens; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.tokens (
    email character varying(50) NOT NULL,
    token character varying(32) NOT NULL
);


ALTER TABLE public.tokens OWNER TO api;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: api
--

CREATE SEQUENCE public.users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO api;

--
-- Name: users; Type: TABLE; Schema: public; Owner: api
--

CREATE TABLE public.users (
    id integer DEFAULT nextval('public.users_id_seq'::regclass) NOT NULL,
    email character varying(255) NOT NULL,
    first character varying(10) NOT NULL,
    last character varying(15) NOT NULL,
    positions integer[],
    display character varying(10)
);


ALTER TABLE public.users OWNER TO api;

--
-- Name: positions id; Type: DEFAULT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.positions ALTER COLUMN id SET DEFAULT nextval('public.positions_id_seq'::regclass);


--
-- Name: schedule id; Type: DEFAULT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.schedule ALTER COLUMN id SET DEFAULT nextval('public.schedule_id_seq'::regclass);


--
-- Name: templates id; Type: DEFAULT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.templates ALTER COLUMN id SET DEFAULT nextval('public.templates_id_seq'::regclass);


--
-- Name: timesheets id; Type: DEFAULT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.timesheets ALTER COLUMN id SET DEFAULT nextval('public.timesheets_id_seq'::regclass);


--
-- Data for Name: logins; Type: TABLE DATA; Schema: public; Owner: api
--

-- To explain why the logins have the same hash/salt, I copy pasted the password from one account to the rest
COPY public.logins (email, password, "group", enabled) FROM stdin;
example1@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example2@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example3@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example4@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example5@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example6@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example7@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example8@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example9@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example10@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
example11@mail.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	1	t
admin@domain.com	$2a$11$wLY8Fipi8lLhMKT7W8qGR.qgN.etNY7jCJQ4TvmtjU1Hqnp3KiEqC	0	t
\.


--
-- Data for Name: positions; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.positions (id, title) FROM stdin;
1	Cook
2	Barista
3	Kitchen
4	Counter
\.


--
-- Data for Name: schedule; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.schedule (id, user_id, start, "end", position_id, published) FROM stdin;
2841	10	2021-10-03 20:00:00.007+00	2021-10-04 05:00:00.007+00	2	t
2842	12	2021-10-04 01:00:00.617+00	2021-10-04 10:00:00.617+00	2	t
2746	5	2021-10-03 00:00:00.171+00	2021-10-03 10:00:00.171+00	1	t
2751	14	2021-10-01 02:00:00.389+00	2021-10-01 10:00:00.389+00	1	t
2763	11	2021-10-03 00:00:00.389+00	2021-10-03 10:00:00.389+00	3	t
2764	11	2021-10-01 20:00:00.389+00	2021-10-02 05:00:00.389+00	3	t
2771	13	2021-10-01 06:30:00.389+00	2021-10-01 10:00:00.389+00	3	t
2774	10	2021-10-01 06:00:00.389+00	2021-10-01 10:00:00.389+00	2	t
2789	12	2021-10-02 04:00:00.999+00	2021-10-02 10:00:00.999+00	2	t
2790	12	2021-10-03 03:00:00.999+00	2021-10-03 10:00:00.999+00	2	t
2791	10	2021-10-01 20:00:00.999+00	2021-10-02 04:00:00.999+00	2	t
2792	10	2021-10-02 20:00:00.999+00	2021-10-03 04:00:00.999+00	2	t
2802	6	2021-10-01 19:30:00.484+00	2021-10-02 03:00:00.484+00	1	t
2803	6	2021-10-02 05:00:00.484+00	2021-10-02 10:00:00.484+00	1	t
2801	6	2021-10-02 19:30:00.105+00	2021-10-03 03:00:00.105+00	1	t
2804	5	2021-10-01 20:00:00.291+00	2021-10-02 03:00:00.291+00	4	t
2805	5	2021-10-02 03:00:00.291+00	2021-10-02 05:00:00.291+00	1	t
2806	18	2021-10-02 03:00:00.291+00	2021-10-02 10:00:00.291+00	4	t
2816	17	2021-10-01 02:00:00.291+00	2021-10-01 10:00:00.291+00	4	t
2776	7	2021-10-01 06:00:00.291+00	2021-10-01 10:00:00.291+00	3	t
2807	18	2021-10-02 22:00:00.291+00	2021-10-03 07:00:00.291+00	4	t
2818	7	2021-10-02 20:00:00.291+00	2021-10-03 04:00:00.291+00	3	t
2817	7	2021-10-02 04:00:00.291+00	2021-10-02 10:00:00.291+00	3	t
2772	13	2021-10-01 20:00:00.291+00	2021-10-02 04:00:00.291+00	3	t
2843	10	2021-10-04 20:00:00.299+00	2021-10-05 04:00:00.299+00	2	t
2844	10	2021-10-07 04:00:00.299+00	2021-10-07 10:00:00.299+00	2	t
2849	12	2021-10-05 03:00:00.299+00	2021-10-05 10:00:00.299+00	2	t
2883	7	2021-10-07 20:00:00.821+00	2021-10-08 03:00:00.821+00	3	t
2852	12	2021-10-06 20:00:00.299+00	2021-10-07 04:00:00.299+00	2	t
2853	12	2021-10-09 04:00:00.299+00	2021-10-09 10:00:00.299+00	2	t
2854	12	2021-10-10 03:00:00.299+00	2021-10-10 10:00:00.299+00	2	t
2888	6	2021-10-04 19:30:00.751+00	2021-10-05 04:00:00.751+00	1	t
2890	6	2021-10-05 06:00:00.751+00	2021-10-05 10:00:00.751+00	1	t
2869	13	2021-10-05 06:30:00.299+00	2021-10-05 10:00:00.299+00	3	t
2870	13	2021-10-06 06:30:00.299+00	2021-10-06 10:00:00.299+00	3	t
2871	13	2021-10-07 06:30:00.299+00	2021-10-07 10:00:00.299+00	3	t
2872	13	2021-10-08 06:30:00.299+00	2021-10-08 10:00:00.299+00	3	t
2876	11	2021-10-06 20:00:00.299+00	2021-10-07 05:00:00.299+00	3	t
2878	7	2021-10-04 20:00:00.299+00	2021-10-05 04:00:00.299+00	3	t
2879	7	2021-10-07 04:00:00.299+00	2021-10-07 10:00:00.299+00	3	t
2896	5	2021-10-04 20:00:00.751+00	2021-10-05 02:00:00.751+00	4	t
2848	10	2021-10-09 20:00:00.821+00	2021-10-10 03:00:00.821+00	2	t
2886	7	2021-10-09 04:00:00.299+00	2021-10-09 10:00:00.299+00	3	t
2873	13	2021-10-08 20:00:00.299+00	2021-10-09 04:00:00.299+00	3	t
2898	18	2021-10-05 02:00:00.751+00	2021-10-05 10:00:00.751+00	4	t
2899	5	2021-10-05 04:00:00.751+00	2021-10-05 06:00:00.751+00	1	t
2900	5	2021-10-05 06:00:00.751+00	2021-10-05 10:00:00.751+00	3	t
2874	11	2021-10-04 20:00:00.751+00	2021-10-05 06:00:00.751+00	3	t
2901	5	2021-10-05 20:00:00.751+00	2021-10-06 05:00:00.751+00	4	t
2902	6	2021-10-05 19:30:00.751+00	2021-10-06 04:00:00.751+00	1	t
2903	14	2021-10-06 02:00:00.751+00	2021-10-06 10:00:00.751+00	1	t
2905	6	2021-10-06 19:30:00.821+00	2021-10-07 04:00:00.821+00	1	t
2866	13	2021-10-04 04:00:00.299+00	2021-10-04 10:00:00.299+00	3	t
2892	5	2021-10-03 19:30:00.617+00	2021-10-04 04:30:00.617+00	1	t
2893	6	2021-10-04 01:00:00.617+00	2021-10-04 10:00:00.617+00	1	t
2894	11	2021-10-03 20:00:00.617+00	2021-10-04 05:00:00.617+00	3	t
2867	18	2021-10-04 01:00:00.617+00	2021-10-04 10:00:00.617+00	4	t
2895	7	2021-10-04 01:00:00.617+00	2021-10-04 10:00:00.617+00	3	t
2906	14	2021-10-07 02:00:00.821+00	2021-10-07 10:00:00.821+00	1	t
2907	14	2021-10-08 02:00:00.821+00	2021-10-08 10:00:00.821+00	1	t
2908	6	2021-10-07 19:30:00.821+00	2021-10-08 03:00:00.821+00	1	t
2910	14	2021-10-08 19:30:00.821+00	2021-10-09 04:00:00.821+00	1	t
2884	7	2021-10-08 05:00:00.821+00	2021-10-08 10:00:00.821+00	3	t
2915	5	2021-10-09 02:00:00.821+00	2021-10-09 10:00:00.821+00	1	t
2916	5	2021-10-09 19:30:00.821+00	2021-10-10 04:00:00.821+00	1	t
2917	14	2021-10-10 02:00:00.821+00	2021-10-10 10:00:00.821+00	1	t
2918	11	2021-10-08 20:00:00.821+00	2021-10-09 05:00:00.821+00	3	t
2919	11	2021-10-10 00:00:00.821+00	2021-10-10 10:00:00.821+00	3	t
2923	17	2021-10-10 03:00:00.821+00	2021-10-10 10:00:00.821+00	4	t
2924	18	2021-10-09 03:00:00.821+00	2021-10-09 10:00:00.821+00	4	t
2922	17	2021-10-08 20:00:00.821+00	2021-10-09 03:00:00.821+00	4	t
2925	18	2021-10-09 20:00:00.821+00	2021-10-10 03:00:00.821+00	4	t
2847	10	2021-10-08 20:00:00.821+00	2021-10-09 04:00:00.821+00	2	t
2887	7	2021-10-09 20:00:00.821+00	2021-10-10 03:00:00.821+00	3	t
2850	12	2021-10-05 20:00:00.821+00	2021-10-06 03:00:00.821+00	2	t
2851	12	2021-10-06 05:00:00.821+00	2021-10-06 10:00:00.821+00	2	t
2926	17	2021-10-08 02:00:00.821+00	2021-10-08 10:00:00.821+00	4	t
2928	17	2021-10-06 21:00:00.821+00	2021-10-07 05:00:00.821+00	4	t
2912	11	2021-10-05 20:00:00.821+00	2021-10-06 06:00:00.821+00	3	t
2845	10	2021-10-07 20:00:00.821+00	2021-10-08 03:00:00.821+00	2	t
2913	17	2021-10-06 02:00:00.821+00	2021-10-06 08:00:00.821+00	4	t
2929	17	2021-10-06 08:00:00.821+00	2021-10-06 10:00:00.821+00	3	t
2920	18	2021-10-07 20:00:00.821+00	2021-10-08 05:00:00.821+00	4	t
2846	10	2021-10-08 05:00:00.821+00	2021-10-08 10:00:00.821+00	2	t
2930	5	2021-10-10 19:30:00.68+00	2021-10-11 04:00:00.68+00	1	t
2932	14	2021-10-11 02:00:00.68+00	2021-10-11 10:00:00.68+00	1	t
2933	14	2021-10-12 02:00:00.68+00	2021-10-12 10:00:00.68+00	1	t
2934	7	2021-10-10 20:00:00.68+00	2021-10-11 03:00:00.68+00	3	t
2935	7	2021-10-13 04:00:00.68+00	2021-10-13 10:00:00.68+00	3	t
2936	10	2021-10-10 20:00:00.68+00	2021-10-11 03:00:00.68+00	2	t
2937	10	2021-10-13 04:00:00.68+00	2021-10-13 10:00:00.68+00	2	t
2938	11	2021-10-11 00:00:00.68+00	2021-10-11 10:00:00.68+00	3	t
2939	11	2021-10-11 20:00:00.68+00	2021-10-12 05:00:00.68+00	3	t
2940	11	2021-10-12 20:00:00.68+00	2021-10-13 05:00:00.68+00	3	t
2942	11	2021-10-15 20:00:00.68+00	2021-10-16 05:00:00.68+00	3	t
2943	11	2021-10-17 00:00:00.68+00	2021-10-17 10:00:00.68+00	3	t
2946	12	2021-10-12 20:00:00.68+00	2021-10-13 04:00:00.68+00	2	t
3004	17	2021-10-15 03:00:00.639+00	2021-10-15 10:00:00.639+00	4	t
3012	4	2021-10-18 03:00:00.588+00	2021-10-18 10:00:00.588+00	2	t
3013	4	2021-10-19 03:00:00.588+00	2021-10-19 10:00:00.588+00	2	t
3024	14	2021-10-18 02:00:00.83+00	2021-10-18 10:00:00.83+00	1	t
3025	5	2021-10-17 19:30:00.83+00	2021-10-18 04:00:00.83+00	1	t
3026	5	2021-10-18 19:30:00.83+00	2021-10-19 03:00:00.83+00	1	t
3027	5	2021-10-19 05:00:00.83+00	2021-10-19 10:00:00.83+00	3	t
3029	13	2021-10-18 07:00:00.83+00	2021-10-18 10:00:00.83+00	3	t
3030	13	2021-10-19 07:00:00.83+00	2021-10-19 10:00:00.83+00	3	t
3031	11	2021-10-18 00:00:00.83+00	2021-10-18 10:00:00.83+00	3	t
3035	11	2021-10-20 20:00:00.83+00	2021-10-21 05:00:00.83+00	3	t
3036	11	2021-10-22 20:00:00.83+00	2021-10-23 05:00:00.83+00	3	t
3037	11	2021-10-24 00:00:00.83+00	2021-10-24 10:00:00.83+00	3	t
3039	10	2021-10-17 20:00:00.097+00	2021-10-18 03:00:00.097+00	2	t
3043	7	2021-10-17 20:00:00.097+00	2021-10-18 03:00:00.097+00	3	t
3047	6	2021-10-19 19:30:00.097+00	2021-10-20 04:00:00.097+00	1	t
3048	14	2021-10-20 02:00:00.097+00	2021-10-20 10:00:00.097+00	1	t
2954	7	2021-10-16 03:00:00.68+00	2021-10-16 10:00:00.68+00	3	t
2955	7	2021-10-16 20:00:00.68+00	2021-10-17 04:00:00.68+00	3	t
2957	12	2021-10-11 20:00:00.68+00	2021-10-12 04:00:00.68+00	2	t
2958	12	2021-10-12 06:00:00.68+00	2021-10-12 10:00:00.68+00	2	t
2959	12	2021-10-16 04:00:00.68+00	2021-10-16 10:00:00.68+00	2	t
2960	12	2021-10-17 04:00:00.68+00	2021-10-17 10:00:00.68+00	2	t
2962	10	2021-10-15 20:00:00.68+00	2021-10-16 05:00:00.68+00	2	t
2963	10	2021-10-16 20:00:00.68+00	2021-10-17 05:00:00.68+00	2	t
2965	6	2021-10-12 19:30:00.68+00	2021-10-13 04:00:00.68+00	1	t
2966	14	2021-10-13 02:00:00.68+00	2021-10-13 10:00:00.68+00	1	t
2967	6	2021-10-13 19:30:00.68+00	2021-10-14 04:00:00.68+00	1	t
2969	6	2021-10-15 19:30:00.68+00	2021-10-16 03:00:00.68+00	1	t
2970	6	2021-10-16 05:00:00.68+00	2021-10-16 10:00:00.68+00	1	t
2973	6	2021-10-14 19:30:00.68+00	2021-10-15 04:00:00.68+00	1	t
2975	14	2021-10-14 02:00:00.68+00	2021-10-14 10:00:00.68+00	1	t
2974	14	2021-10-15 02:00:00.68+00	2021-10-15 10:00:00.68+00	1	t
2976	13	2021-10-11 07:00:00.68+00	2021-10-11 10:00:00.68+00	3	t
2977	13	2021-10-12 07:00:00.68+00	2021-10-12 10:00:00.68+00	3	t
2978	13	2021-10-13 07:00:00.68+00	2021-10-13 10:00:00.68+00	3	t
2979	13	2021-10-14 07:00:00.68+00	2021-10-14 10:00:00.68+00	3	t
2980	13	2021-10-15 07:00:00.68+00	2021-10-15 10:00:00.68+00	3	t
2981	13	2021-10-15 20:00:00.68+00	2021-10-16 03:00:00.68+00	3	t
2982	5	2021-10-12 20:00:00.97+00	2021-10-13 04:00:00.97+00	4	t
2987	11	2021-10-13 20:00:00.639+00	2021-10-14 05:00:00.639+00	3	t
2989	12	2021-10-13 20:00:00.639+00	2021-10-14 03:00:00.639+00	2	t
2992	10	2021-10-14 03:00:00.639+00	2021-10-14 10:00:00.639+00	2	t
2964	5	2021-10-16 02:00:00.639+00	2021-10-16 10:00:00.639+00	4	t
2996	18	2021-10-15 20:00:00.639+00	2021-10-16 03:00:00.639+00	4	t
2997	18	2021-10-17 02:00:00.639+00	2021-10-17 10:00:00.639+00	4	t
2999	18	2021-10-11 04:00:00.639+00	2021-10-11 10:00:00.639+00	4	t
3000	17	2021-10-10 20:00:00.639+00	2021-10-11 04:00:00.639+00	4	t
2931	5	2021-10-11 19:30:00.639+00	2021-10-12 03:00:00.639+00	1	t
3002	5	2021-10-12 05:00:00.639+00	2021-10-12 10:00:00.639+00	3	t
3005	17	2021-10-14 03:00:00.639+00	2021-10-14 10:00:00.639+00	4	t
3006	7	2021-10-14 03:00:00.639+00	2021-10-14 10:00:00.639+00	3	t
2993	17	2021-10-13 03:00:00.639+00	2021-10-13 10:00:00.639+00	4	t
3009	18	2021-10-13 20:00:00.639+00	2021-10-14 03:00:00.639+00	4	t
2998	18	2021-10-14 20:00:00.639+00	2021-10-15 05:00:00.639+00	4	t
3007	7	2021-10-14 20:00:00.639+00	2021-10-15 03:00:00.639+00	3	t
3008	7	2021-10-15 05:00:00.639+00	2021-10-15 10:00:00.639+00	3	t
2990	10	2021-10-14 20:00:00.639+00	2021-10-15 03:00:00.639+00	2	t
2991	10	2021-10-15 05:00:00.639+00	2021-10-15 10:00:00.639+00	2	t
3011	5	2021-10-16 19:30:00.144+00	2021-10-17 04:00:00.144+00	1	t
2971	6	2021-10-17 03:00:00.144+00	2021-10-17 10:00:00.144+00	1	t
3010	17	2021-10-11 22:00:00.144+00	2021-10-12 06:00:00.144+00	4	t
2956	12	2021-10-11 02:00:00.144+00	2021-10-11 10:00:00.144+00	2	t
3106	12	2021-10-19 05:00:00.291+00	2021-10-19 10:00:00.291+00	4	t
3098	7	2021-10-23 03:00:00.251+00	2021-10-23 10:00:00.251+00	3	t
3028	14	2021-10-19 02:00:00.83+00	2021-10-19 10:00:00.83+00	1	t
3034	11	2021-10-19 20:00:00.83+00	2021-10-20 05:00:00.83+00	3	t
3053	14	2021-10-21 02:00:00.097+00	2021-10-21 10:00:00.097+00	1	t
3054	6	2021-10-20 19:30:00.097+00	2021-10-21 04:00:00.097+00	1	t
3055	6	2021-10-21 19:30:00.097+00	2021-10-22 04:00:00.097+00	1	t
3056	6	2021-10-22 19:30:00.097+00	2021-10-23 03:00:00.097+00	1	t
3057	6	2021-10-23 05:00:00.097+00	2021-10-23 10:00:00.097+00	1	t
3058	6	2021-10-23 19:30:00.097+00	2021-10-24 03:00:00.097+00	1	t
3059	14	2021-10-22 02:00:00.097+00	2021-10-22 10:00:00.097+00	1	t
3089	5	2021-10-21 20:00:00.352+00	2021-10-22 05:00:00.352+00	4	t
3066	7	2021-10-23 20:00:00.74+00	2021-10-24 04:00:00.74+00	3	t
3094	7	2021-10-20 04:00:00.352+00	2021-10-20 10:00:00.352+00	3	t
3072	10	2021-10-21 03:00:00.352+00	2021-10-21 10:00:00.352+00	2	t
3073	10	2021-10-22 20:00:00.74+00	2021-10-23 05:00:00.74+00	2	t
3074	10	2021-10-23 20:00:00.74+00	2021-10-24 05:00:00.74+00	2	t
3075	12	2021-10-19 20:00:00.74+00	2021-10-20 04:00:00.74+00	2	t
3077	12	2021-10-20 20:00:00.74+00	2021-10-21 04:00:00.74+00	2	t
3063	10	2021-10-21 20:00:00.74+00	2021-10-22 02:00:00.74+00	2	t
3064	10	2021-10-22 04:00:00.74+00	2021-10-22 10:00:00.74+00	2	t
3083	10	2021-10-20 04:00:00.74+00	2021-10-20 10:00:00.74+00	2	t
3084	12	2021-10-18 20:00:00.74+00	2021-10-19 03:00:00.74+00	2	t
3086	17	2021-10-19 21:00:00.74+00	2021-10-20 05:00:00.74+00	4	t
3061	17	2021-10-20 21:00:00.74+00	2021-10-21 05:00:00.74+00	4	t
3062	17	2021-10-22 02:00:00.74+00	2021-10-22 10:00:00.74+00	4	t
3070	12	2021-10-24 02:00:00.74+00	2021-10-24 10:00:00.74+00	2	t
3087	5	2021-10-22 20:00:00.251+00	2021-10-23 03:00:00.251+00	4	t
3088	5	2021-10-23 03:00:00.251+00	2021-10-23 05:00:00.251+00	1	t
3090	13	2021-10-20 07:00:00.251+00	2021-10-20 10:00:00.251+00	3	t
3091	13	2021-10-21 07:00:00.251+00	2021-10-21 10:00:00.251+00	3	t
3092	13	2021-10-22 07:00:00.251+00	2021-10-22 10:00:00.251+00	3	t
3093	13	2021-10-22 20:00:00.251+00	2021-10-23 03:00:00.251+00	3	t
3081	12	2021-10-17 20:00:00.251+00	2021-10-18 05:00:00.251+00	4	t
3095	7	2021-10-21 03:00:00.251+00	2021-10-21 10:00:00.251+00	3	t
3096	7	2021-10-21 20:00:00.251+00	2021-10-22 02:00:00.251+00	3	t
3097	7	2021-10-22 04:00:00.251+00	2021-10-22 10:00:00.251+00	3	t
3100	17	2021-10-18 04:00:00.824+00	2021-10-18 10:00:00.824+00	4	t
3101	17	2021-10-18 21:00:00.824+00	2021-10-19 05:00:00.824+00	4	t
3103	5	2021-10-24 00:00:00.824+00	2021-10-24 03:00:00.824+00	4	t
3104	5	2021-10-24 03:00:00.824+00	2021-10-24 10:00:00.824+00	1	t
3085	12	2021-10-23 03:00:00.824+00	2021-10-23 10:00:00.824+00	2	t
3032	11	2021-10-18 20:00:00.291+00	2021-10-19 06:00:00.291+00	3	t
\.


--
-- Data for Name: templates; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.templates (id, start, "end", position_id) FROM stdin;
1	05:45	12:00	1
2	06:00	12:00	2
3	06:00	12:00	3
4	12:00	20:00	1
5	12:00	20:00	2
6	12:00	20:00	3
7	07:00	14:00	2
8	13:00	20:00	2
9	13:00	20:00	2
10	06:00	15:00	3
11	10:00	20:00	3
12	14:00	20:00	3
13	06:00	13:00	2
14	14:00	20:00	2
15	15:00	20:00	4
16	16:30	20:00	3
17	13:00	20:00	3
18	16:30	20:00	3
19	07:00	15:00	4
20	17:00	20:00	3
21	17:00	20:00	3
\.


--
-- Data for Name: timesheets; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.timesheets (id, schedule_id, user_id, start, "end") FROM stdin;
\.


--
-- Data for Name: tokens; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.tokens (email, token) FROM stdin;
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: api
--

COPY public.users (id, email, first, last, positions, display) FROM stdin;
1	admin@domain.com	Admin	User	{2,4}	\N
4	example1@mail.com	Harry	Schurr	{2}	\N
5	example2@mail.com	James	Oldaker	{1,3,4}	\N
11	example3@mail.com	Dominic	Tilly	{3,4}	\N
12	example4@mail.com	Ethan	Nemarluk	{1,2,3,4}	\N
18	example5@mail.com	May	Archer	{4}	\N
17	example6@mail.com	John	Wilshire	{3,4}	John
6	example7@mail.com	Sebastian	Butlin	{1,3}	Seb
13	example8@mail.com	Joshua	Garden	{3,4}	Josh
7	example9@mail.com	Madeline	Traill	{3}	\N
10	example10@mail.com	Mick	Mulquin	{2}	\N
14	example11@mail.com	Eliza	McGirr	{1}	\N
\.


--
-- Name: positions_id_seq; Type: SEQUENCE SET; Schema: public; Owner: api
--

SELECT pg_catalog.setval('public.positions_id_seq', 4, true);


--
-- Name: schedule_id_seq; Type: SEQUENCE SET; Schema: public; Owner: api
--

SELECT pg_catalog.setval('public.schedule_id_seq', 3106, true);


--
-- Name: templates_id_seq; Type: SEQUENCE SET; Schema: public; Owner: api
--

SELECT pg_catalog.setval('public.templates_id_seq', 21, true);


--
-- Name: timesheets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: api
--

SELECT pg_catalog.setval('public.timesheets_id_seq', 1866, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: api
--

SELECT pg_catalog.setval('public.users_id_seq', 18, true);


--
-- Name: tokens idx_17189_primary; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.tokens
    ADD CONSTRAINT idx_17189_primary PRIMARY KEY (email);


--
-- Name: positions positions_pkey; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.positions
    ADD CONSTRAINT positions_pkey PRIMARY KEY (id);


--
-- Name: schedule schedule_pkey; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (id);


--
-- Name: templates templates_pkey; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.templates
    ADD CONSTRAINT templates_pkey PRIMARY KEY (id);


--
-- Name: timesheets timesheets_pkey; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.timesheets
    ADD CONSTRAINT timesheets_pkey PRIMARY KEY (id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: schedule schedule_position_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_position_id_fkey FOREIGN KEY (position_id) REFERENCES public.positions(id);


--
-- Name: schedule schedule_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: templates templates_position_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: api
--

ALTER TABLE ONLY public.templates
    ADD CONSTRAINT templates_position_id_fkey FOREIGN KEY (position_id) REFERENCES public.positions(id);


--
-- PostgreSQL database dump complete
--

