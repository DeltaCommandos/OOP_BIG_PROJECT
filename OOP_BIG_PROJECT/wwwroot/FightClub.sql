PGDMP                      |         	   FightClub    16.3    16.3 (    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16431 	   FightClub    DATABASE        CREATE DATABASE "FightClub" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FightClub";
                postgres    false            �            1259    16432    Fighter    TABLE     �   CREATE TABLE public."Fighter" (
    id integer NOT NULL,
    name character varying NOT NULL,
    id_rating integer NOT NULL,
    sex boolean NOT NULL,
    age integer NOT NULL,
    features character varying NOT NULL
);
    DROP TABLE public."Fighter";
       public         heap    postgres    false            �            1259    16435    Main    TABLE     �   CREATE TABLE public."Main" (
    id integer NOT NULL,
    id_fighter1 integer NOT NULL,
    id_fighter2 integer NOT NULL,
    id_arena integer NOT NULL,
    "time" integer[] NOT NULL,
    price integer NOT NULL,
    id_rules integer NOT NULL
);
    DROP TABLE public."Main";
       public         heap    postgres    false            �            1259    24647    Fighter_id_seq    SEQUENCE     �   ALTER TABLE public."Main" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Fighter_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    216            �            1259    24665    Fighter_id_seq1    SEQUENCE     �   ALTER TABLE public."Fighter" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Fighter_id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    24679    FreeTime    TABLE     [   CREATE TABLE public."FreeTime" (
    id integer NOT NULL,
    "time" integer[] NOT NULL
);
    DROP TABLE public."FreeTime";
       public         heap    postgres    false            �            1259    24713    FreeTime_id_seq    SEQUENCE     �   ALTER TABLE public."FreeTime" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."FreeTime_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    223            �            1259    16444 	   Judgement    TABLE     �   CREATE TABLE public."Judgement" (
    id integer NOT NULL,
    name character varying(30) NOT NULL,
    rating integer NOT NULL
);
    DROP TABLE public."Judgement";
       public         heap    postgres    false            �            1259    24655    Judgement_id_seq    SEQUENCE     �   ALTER TABLE public."Judgement" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Judgement_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219            �            1259    16438    Place    TABLE     s   CREATE TABLE public."Place" (
    id integer NOT NULL,
    type boolean NOT NULL,
    capacity integer NOT NULL
);
    DROP TABLE public."Place";
       public         heap    postgres    false            �            1259    16441    Rules    TABLE     �   CREATE TABLE public."Rules" (
    id integer NOT NULL,
    name character varying NOT NULL,
    ending character varying NOT NULL,
    id_judge integer NOT NULL
);
    DROP TABLE public."Rules";
       public         heap    postgres    false            �            1259    24682    User    TABLE     �   CREATE TABLE public."User" (
    id integer NOT NULL,
    login character varying NOT NULL,
    password character varying NOT NULL
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    24685    User_id_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    224            �          0    16432    Fighter 
   TABLE DATA           L   COPY public."Fighter" (id, name, id_rating, sex, age, features) FROM stdin;
    public          postgres    false    215   �+       �          0    24679    FreeTime 
   TABLE DATA           0   COPY public."FreeTime" (id, "time") FROM stdin;
    public          postgres    false    223   �+       �          0    16444 	   Judgement 
   TABLE DATA           7   COPY public."Judgement" (id, name, rating) FROM stdin;
    public          postgres    false    219   �+       �          0    16435    Main 
   TABLE DATA           a   COPY public."Main" (id, id_fighter1, id_fighter2, id_arena, "time", price, id_rules) FROM stdin;
    public          postgres    false    216   ,       �          0    16438    Place 
   TABLE DATA           5   COPY public."Place" (id, type, capacity) FROM stdin;
    public          postgres    false    217   6,       �          0    16441    Rules 
   TABLE DATA           =   COPY public."Rules" (id, name, ending, id_judge) FROM stdin;
    public          postgres    false    218   S,       �          0    24682    User 
   TABLE DATA           5   COPY public."User" (id, login, password) FROM stdin;
    public          postgres    false    224   p,       �           0    0    Fighter_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Fighter_id_seq"', 1, false);
          public          postgres    false    220            �           0    0    Fighter_id_seq1    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Fighter_id_seq1"', 1, false);
          public          postgres    false    222            �           0    0    FreeTime_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."FreeTime_id_seq"', 1, false);
          public          postgres    false    226            �           0    0    Judgement_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Judgement_id_seq"', 1, false);
          public          postgres    false    221            �           0    0    User_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."User_id_seq"', 1, false);
          public          postgres    false    225            9           2606    24652    Main Fighter_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public."Main"
    ADD CONSTRAINT "Fighter_pkey" PRIMARY KEY (id);
 ?   ALTER TABLE ONLY public."Main" DROP CONSTRAINT "Fighter_pkey";
       public            postgres    false    216            7           2606    24670    Fighter Fighter_pkey1 
   CONSTRAINT     W   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "Fighter_pkey1" PRIMARY KEY (id);
 C   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "Fighter_pkey1";
       public            postgres    false    215            A           2606    24718    FreeTime FreeTime_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."FreeTime"
    ADD CONSTRAINT "FreeTime_pkey" PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."FreeTime" DROP CONSTRAINT "FreeTime_pkey";
       public            postgres    false    223            ?           2606    24664    Judgement Judgement_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Judgement"
    ADD CONSTRAINT "Judgement_pkey" PRIMARY KEY (id);
 F   ALTER TABLE ONLY public."Judgement" DROP CONSTRAINT "Judgement_pkey";
       public            postgres    false    219            ;           2606    24674    Place Place_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Place"
    ADD CONSTRAINT "Place_pkey" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public."Place" DROP CONSTRAINT "Place_pkey";
       public            postgres    false    217            =           2606    24678    Rules Rules_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Rules"
    ADD CONSTRAINT "Rules_pkey" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public."Rules" DROP CONSTRAINT "Rules_pkey";
       public            postgres    false    218            C           2606    24692    User User_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    224            D           2606    24703    Main id_arena_fk    FK CONSTRAINT     ~   ALTER TABLE ONLY public."Main"
    ADD CONSTRAINT id_arena_fk FOREIGN KEY (id_arena) REFERENCES public."Place"(id) NOT VALID;
 <   ALTER TABLE ONLY public."Main" DROP CONSTRAINT id_arena_fk;
       public          postgres    false    216    217    4667            E           2606    24693    Main id_fighter1_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Main"
    ADD CONSTRAINT id_fighter1_fk FOREIGN KEY (id_fighter1) REFERENCES public."Fighter"(id) NOT VALID;
 ?   ALTER TABLE ONLY public."Main" DROP CONSTRAINT id_fighter1_fk;
       public          postgres    false    216    4663    215            F           2606    24698    Main id_fighter2_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Main"
    ADD CONSTRAINT id_fighter2_fk FOREIGN KEY (id_fighter2) REFERENCES public."Fighter"(id) NOT VALID;
 ?   ALTER TABLE ONLY public."Main" DROP CONSTRAINT id_fighter2_fk;
       public          postgres    false    215    4663    216            H           2606    24721    Rules id_judge_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Rules"
    ADD CONSTRAINT id_judge_fk FOREIGN KEY (id_judge) REFERENCES public."Judgement"(id) NOT VALID;
 =   ALTER TABLE ONLY public."Rules" DROP CONSTRAINT id_judge_fk;
       public          postgres    false    4671    218    219            G           2606    24708    Main id_rules_fk    FK CONSTRAINT     ~   ALTER TABLE ONLY public."Main"
    ADD CONSTRAINT id_rules_fk FOREIGN KEY (id_rules) REFERENCES public."Rules"(id) NOT VALID;
 <   ALTER TABLE ONLY public."Main" DROP CONSTRAINT id_rules_fk;
       public          postgres    false    4669    218    216            �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �     