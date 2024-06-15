PGDMP      )                |         
   Fight Club    16.3    16.3 !    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16580 
   Fight Club    DATABASE     �   CREATE DATABASE "Fight Club" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Fight Club";
                postgres    false            �            1259    16656    Game    TABLE     �   CREATE TABLE public."Game" (
    "GameId" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Matches" integer NOT NULL
);
    DROP TABLE public."Game";
       public         heap    postgres    false            �            1259    16661    LoginViewModel    TABLE     �   CREATE TABLE public."LoginViewModel" (
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "RememberMe" boolean NOT NULL
);
 $   DROP TABLE public."LoginViewModel";
       public         heap    postgres    false            �            1259    16666    Match    TABLE       CREATE TABLE public."Match" (
    "Id" integer NOT NULL,
    "UserId1" integer NOT NULL,
    "UserId2" integer NOT NULL,
    "GameId" integer NOT NULL,
    "PlaceId" integer NOT NULL,
    "IsAccepted" boolean NOT NULL,
    "ScheduledTime" time without time zone NOT NULL
);
    DROP TABLE public."Match";
       public         heap    postgres    false            �            1259    16669    Message    TABLE     �   CREATE TABLE public."Message" (
    "MessageId" integer NOT NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "Content" character varying NOT NULL,
    "Timestamp" timestamp with time zone NOT NULL
);
    DROP TABLE public."Message";
       public         heap    postgres    false            �            1259    16674    Person    TABLE     �   CREATE TABLE public."Person" (
    "ID" integer NOT NULL,
    "Name" character varying NOT NULL,
    "AccountID" integer NOT NULL
);
    DROP TABLE public."Person";
       public         heap    postgres    false            �            1259    16603    Place    TABLE     �   CREATE TABLE public."Place" (
    "PlaceId" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Location" character varying NOT NULL
);
    DROP TABLE public."Place";
       public         heap    postgres    false            �            1259    16679    RegisterViewModel    TABLE     �   CREATE TABLE public."RegisterViewModel" (
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "ConfirmPassword" character varying NOT NULL
);
 '   DROP TABLE public."RegisterViewModel";
       public         heap    postgres    false            �            1259    16611    User    TABLE     �   CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    16616    User_id_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN "UserId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    216            �          0    16656    Game 
   TABLE DATA           =   COPY public."Game" ("GameId", "Name", "Matches") FROM stdin;
    public          postgres    false    218   �%       �          0    16661    LoginViewModel 
   TABLE DATA           P   COPY public."LoginViewModel" ("Username", "Password", "RememberMe") FROM stdin;
    public          postgres    false    219   �%       �          0    16666    Match 
   TABLE DATA           q   COPY public."Match" ("Id", "UserId1", "UserId2", "GameId", "PlaceId", "IsAccepted", "ScheduledTime") FROM stdin;
    public          postgres    false    220   �%       �          0    16669    Message 
   TABLE DATA           b   COPY public."Message" ("MessageId", "SenderId", "ReceiverId", "Content", "Timestamp") FROM stdin;
    public          postgres    false    221   �%       �          0    16674    Person 
   TABLE DATA           =   COPY public."Person" ("ID", "Name", "AccountID") FROM stdin;
    public          postgres    false    222    &       �          0    16603    Place 
   TABLE DATA           @   COPY public."Place" ("PlaceId", "Name", "Location") FROM stdin;
    public          postgres    false    215   &       �          0    16679    RegisterViewModel 
   TABLE DATA           X   COPY public."RegisterViewModel" ("Username", "Password", "ConfirmPassword") FROM stdin;
    public          postgres    false    223   :&       �          0    16611    User 
   TABLE DATA           B   COPY public."User" ("UserId", "Username", "Password") FROM stdin;
    public          postgres    false    216   W&       �           0    0    User_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."User_id_seq"', 1, false);
          public          postgres    false    217            ;           2606    16694    Game Game_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "Game_pkey" PRIMARY KEY ("GameId");
 <   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "Game_pkey";
       public            postgres    false    218            =           2606    16696    Match Match_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "Match_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "Match_pkey";
       public            postgres    false    220            7           2606    16626    Place Place_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Place"
    ADD CONSTRAINT "Place_pkey" PRIMARY KEY ("PlaceId");
 >   ALTER TABLE ONLY public."Place" DROP CONSTRAINT "Place_pkey";
       public            postgres    false    215            9           2606    16630    User User_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    216            C           2606    16722    Message ReceiverId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "ReceiverId" FOREIGN KEY ("ReceiverId") REFERENCES public."User"("UserId") NOT VALID;
 @   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "ReceiverId";
       public          postgres    false    4665    216    221            D           2606    16717    Message SenderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "SenderId" FOREIGN KEY ("SenderId") REFERENCES public."User"("UserId") NOT VALID;
 >   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "SenderId";
       public          postgres    false    216    4665    221            ?           2606    16697    Match fk_GameId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_GameId" FOREIGN KEY ("GameId") REFERENCES public."Game"("GameId") NOT VALID;
 =   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_GameId";
       public          postgres    false    218    220    4667            >           2606    16727    Game fk_Matches    FK CONSTRAINT     �   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "fk_Matches" FOREIGN KEY ("Matches") REFERENCES public."Match"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "fk_Matches";
       public          postgres    false    218    4669    220            @           2606    16702    Match fk_PlaceId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_PlaceId" FOREIGN KEY ("PlaceId") REFERENCES public."Place"("PlaceId") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_PlaceId";
       public          postgres    false    220    215    4663            A           2606    16707    Match fk_UserId1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId1" FOREIGN KEY ("UserId1") REFERENCES public."User"("UserId") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId1";
       public          postgres    false    4665    216    220            B           2606    16712    Match fk_UserId2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId2" FOREIGN KEY ("UserId2") REFERENCES public."User"("UserId") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId2";
       public          postgres    false    216    220    4665            �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �     