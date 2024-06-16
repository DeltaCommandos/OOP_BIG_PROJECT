PGDMP                        |         	   FightClub    16.3    16.3 +    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    41230 	   FightClub    DATABASE        CREATE DATABASE "FightClub" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FightClub";
                postgres    false            �            1259    41231    Admin    TABLE     o   CREATE TABLE public."Admin" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "UserId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false            �            1259    41236    Admin_Id_seq    SEQUENCE     �   ALTER TABLE public."Admin" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Admin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    41237    Fighter    TABLE     �   CREATE TABLE public."Fighter" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "Rating" integer,
    "Sex" boolean,
    "Age" integer,
    "Skills" character varying,
    "UserId" integer
);
    DROP TABLE public."Fighter";
       public         heap    postgres    false            �            1259    41242    Fighter_Id_seq    SEQUENCE     �   ALTER TABLE public."Fighter" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Fighter_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    41243    Game    TABLE     �   CREATE TABLE public."Game" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Matches" integer NOT NULL
);
    DROP TABLE public."Game";
       public         heap    postgres    false            �            1259    41248    Match    TABLE       CREATE TABLE public."Match" (
    "Id" integer NOT NULL,
    "UserId1" integer NOT NULL,
    "UserId2" integer NOT NULL,
    "GameId" integer NOT NULL,
    "PlaceId" integer NOT NULL,
    "IsAccepted" boolean NOT NULL,
    "ScheduledTime" time without time zone NOT NULL
);
    DROP TABLE public."Match";
       public         heap    postgres    false            �            1259    41251    Message    TABLE     �   CREATE TABLE public."Message" (
    "Id" integer NOT NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "Content" character varying NOT NULL,
    "Timestamp" timestamp with time zone NOT NULL
);
    DROP TABLE public."Message";
       public         heap    postgres    false            �            1259    41256    Person    TABLE     �   CREATE TABLE public."Person" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "AccountId" integer NOT NULL
);
    DROP TABLE public."Person";
       public         heap    postgres    false            �            1259    41261    Place    TABLE     �   CREATE TABLE public."Place" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Location" character varying NOT NULL
);
    DROP TABLE public."Place";
       public         heap    postgres    false            �            1259    41266    User    TABLE     �   CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "AdminStatus" boolean,
    "Status" boolean
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    41271    User_id_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    224            �          0    41231    Admin 
   TABLE DATA           9   COPY public."Admin" ("Id", "Name", "UserId") FROM stdin;
    public          postgres    false    215   	1       �          0    41237    Fighter 
   TABLE DATA           ]   COPY public."Fighter" ("Id", "Name", "Rating", "Sex", "Age", "Skills", "UserId") FROM stdin;
    public          postgres    false    217   &1       �          0    41243    Game 
   TABLE DATA           9   COPY public."Game" ("Id", "Name", "Matches") FROM stdin;
    public          postgres    false    219   j1       �          0    41248    Match 
   TABLE DATA           q   COPY public."Match" ("Id", "UserId1", "UserId2", "GameId", "PlaceId", "IsAccepted", "ScheduledTime") FROM stdin;
    public          postgres    false    220   �1       �          0    41251    Message 
   TABLE DATA           [   COPY public."Message" ("Id", "SenderId", "ReceiverId", "Content", "Timestamp") FROM stdin;
    public          postgres    false    221   �1       �          0    41256    Person 
   TABLE DATA           =   COPY public."Person" ("Id", "Name", "AccountId") FROM stdin;
    public          postgres    false    222   �1       �          0    41261    Place 
   TABLE DATA           ;   COPY public."Place" ("Id", "Name", "Location") FROM stdin;
    public          postgres    false    223   �1       �          0    41266    User 
   TABLE DATA           W   COPY public."User" ("Id", "Username", "Password", "AdminStatus", "Status") FROM stdin;
    public          postgres    false    224   �1       �           0    0    Admin_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Admin_Id_seq"', 1, false);
          public          postgres    false    216            �           0    0    Fighter_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Fighter_Id_seq"', 11, true);
          public          postgres    false    218            �           0    0    User_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."User_id_seq"', 27, true);
          public          postgres    false    225            9           2606    41273    Admin Admin_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    215            ;           2606    41275    Fighter Fighter_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "Fighter_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "Fighter_pkey";
       public            postgres    false    217            =           2606    41277    Game Game_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "Game_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "Game_pkey";
       public            postgres    false    219            ?           2606    41279    Match Match_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "Match_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "Match_pkey";
       public            postgres    false    220            A           2606    41281    Message Message_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "Message_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "Message_pkey";
       public            postgres    false    221            C           2606    41283    Person Person_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "Person_pkey" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Person" DROP CONSTRAINT "Person_pkey";
       public            postgres    false    222            E           2606    41285    Place Place_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Place"
    ADD CONSTRAINT "Place_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Place" DROP CONSTRAINT "Place_pkey";
       public            postgres    false    223            G           2606    41287    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    224            O           2606    41288    Message ReceiverId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "ReceiverId" FOREIGN KEY ("ReceiverId") REFERENCES public."User"("Id") NOT VALID;
 @   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "ReceiverId";
       public          postgres    false    221    224    4679            P           2606    41293    Message SenderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "SenderId" FOREIGN KEY ("SenderId") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "SenderId";
       public          postgres    false    224    221    4679            K           2606    41298    Match fk_GameId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_GameId" FOREIGN KEY ("GameId") REFERENCES public."Game"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_GameId";
       public          postgres    false    219    4669    220            J           2606    41303    Game fk_Matches    FK CONSTRAINT     �   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "fk_Matches" FOREIGN KEY ("Matches") REFERENCES public."Match"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "fk_Matches";
       public          postgres    false    220    4671    219            L           2606    41308    Match fk_PlaceId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_PlaceId" FOREIGN KEY ("PlaceId") REFERENCES public."Place"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_PlaceId";
       public          postgres    false    220    223    4677            I           2606    41313    Fighter fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    217    224    4679            H           2606    41318    Admin fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    224    215    4679            M           2606    41323    Match fk_UserId1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId1" FOREIGN KEY ("UserId1") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId1";
       public          postgres    false    224    220    4679            N           2606    41328    Match fk_UserId2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId2" FOREIGN KEY ("UserId2") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId2";
       public          postgres    false    220    4679    224            �      x������ � �      �   4   x���,�4�L�{/l���id�eh������&n�eh�YX�&j����� -�      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �   (   x�32�,�4�.#3ΤĤD0�,,!'F��� �
�     