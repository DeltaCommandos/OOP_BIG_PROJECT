PGDMP  ,                    |         
   FightClub1    16.3    16.3 <               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            	           1262    57529 
   FightClub1    DATABASE     �   CREATE DATABASE "FightClub1" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FightClub1";
                postgres    false            �            1259    57530    Admin    TABLE     o   CREATE TABLE public."Admin" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "UserId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false            �            1259    57535    Admin_Id_seq    SEQUENCE     �   ALTER TABLE public."Admin" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Admin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    57536    Fighter    TABLE     ;  CREATE TABLE public."Fighter" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "Rating" integer,
    "Sex" boolean,
    "Age" integer,
    "Skills" character varying,
    "UserId" integer,
    "TagId1" integer,
    "TagId2" integer,
    "TagId3" integer,
    "TagId4" integer,
    "TagId5" integer
);
    DROP TABLE public."Fighter";
       public         heap    postgres    false            �            1259    57541    Fighter_Id_seq    SEQUENCE     �   ALTER TABLE public."Fighter" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Fighter_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    57542    Game    TABLE     �   CREATE TABLE public."Game" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Matches" integer NOT NULL
);
    DROP TABLE public."Game";
       public         heap    postgres    false            �            1259    57547    Likes    TABLE     �   CREATE TABLE public."Likes" (
    "Id" integer NOT NULL,
    "LikerId" integer NOT NULL,
    "LikedFighterId" integer NOT NULL,
    "IsLiked" boolean NOT NULL
);
    DROP TABLE public."Likes";
       public         heap    postgres    false            �            1259    57550    Likes_Id_seq    SEQUENCE     �   ALTER TABLE public."Likes" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Likes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    57551    Match    TABLE       CREATE TABLE public."Match" (
    "Id" integer NOT NULL,
    "UserId1" integer NOT NULL,
    "UserId2" integer NOT NULL,
    "GameId" integer NOT NULL,
    "PlaceId" integer NOT NULL,
    "IsAccepted" boolean NOT NULL,
    "ScheduledTime" time without time zone NOT NULL
);
    DROP TABLE public."Match";
       public         heap    postgres    false            �            1259    57554    Message    TABLE     �   CREATE TABLE public."Message" (
    "Id" integer NOT NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "Content" character varying NOT NULL,
    "Timestamp" timestamp with time zone NOT NULL
);
    DROP TABLE public."Message";
       public         heap    postgres    false            �            1259    57559    Person    TABLE     �   CREATE TABLE public."Person" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "AccountId" integer NOT NULL
);
    DROP TABLE public."Person";
       public         heap    postgres    false            �            1259    57564    Place    TABLE     �   CREATE TABLE public."Place" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Location" character varying NOT NULL
);
    DROP TABLE public."Place";
       public         heap    postgres    false            �            1259    57569    Tags    TABLE     }   CREATE TABLE public."Tags" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "Description" character varying
);
    DROP TABLE public."Tags";
       public         heap    postgres    false            �            1259    57574 
   Tag_Id_seq    SEQUENCE     �   ALTER TABLE public."Tags" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Tag_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    226            �            1259    57575    User    TABLE     �   CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "AdminStatus" boolean,
    "Status" boolean
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    57580    User_id_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    228            �          0    57530    Admin 
   TABLE DATA           9   COPY public."Admin" ("Id", "Name", "UserId") FROM stdin;
    public          postgres    false    215   4F       �          0    57536    Fighter 
   TABLE DATA           �   COPY public."Fighter" ("Id", "Name", "Rating", "Sex", "Age", "Skills", "UserId", "TagId1", "TagId2", "TagId3", "TagId4", "TagId5") FROM stdin;
    public          postgres    false    217   mF       �          0    57542    Game 
   TABLE DATA           9   COPY public."Game" ("Id", "Name", "Matches") FROM stdin;
    public          postgres    false    219   �G       �          0    57547    Likes 
   TABLE DATA           O   COPY public."Likes" ("Id", "LikerId", "LikedFighterId", "IsLiked") FROM stdin;
    public          postgres    false    220   �G       �          0    57551    Match 
   TABLE DATA           q   COPY public."Match" ("Id", "UserId1", "UserId2", "GameId", "PlaceId", "IsAccepted", "ScheduledTime") FROM stdin;
    public          postgres    false    222   1H       �          0    57554    Message 
   TABLE DATA           [   COPY public."Message" ("Id", "SenderId", "ReceiverId", "Content", "Timestamp") FROM stdin;
    public          postgres    false    223   NH       �          0    57559    Person 
   TABLE DATA           =   COPY public."Person" ("Id", "Name", "AccountId") FROM stdin;
    public          postgres    false    224   kH       �          0    57564    Place 
   TABLE DATA           ;   COPY public."Place" ("Id", "Name", "Location") FROM stdin;
    public          postgres    false    225   �H                  0    57569    Tags 
   TABLE DATA           =   COPY public."Tags" ("Id", "Name", "Description") FROM stdin;
    public          postgres    false    226   �H                 0    57575    User 
   TABLE DATA           W   COPY public."User" ("Id", "Username", "Password", "AdminStatus", "Status") FROM stdin;
    public          postgres    false    228   �H       
           0    0    Admin_Id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."Admin_Id_seq"', 3, true);
          public          postgres    false    216                       0    0    Fighter_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Fighter_Id_seq"', 40, true);
          public          postgres    false    218                       0    0    Likes_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Likes_Id_seq"', 24, true);
          public          postgres    false    221                       0    0 
   Tag_Id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public."Tag_Id_seq"', 2, true);
          public          postgres    false    227                       0    0    User_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."User_id_seq"', 61, true);
          public          postgres    false    229            C           2606    57582    Admin Admin_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    215            E           2606    57584    Fighter Fighter_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "Fighter_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "Fighter_pkey";
       public            postgres    false    217            G           2606    57586    Game Game_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "Game_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "Game_pkey";
       public            postgres    false    219            I           2606    57588    Likes Likes_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "Likes_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "Likes_pkey";
       public            postgres    false    220            K           2606    57590    Match Match_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "Match_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "Match_pkey";
       public            postgres    false    222            M           2606    57592    Message Message_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "Message_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "Message_pkey";
       public            postgres    false    223            O           2606    57594    Person Person_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "Person_pkey" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Person" DROP CONSTRAINT "Person_pkey";
       public            postgres    false    224            Q           2606    57596    Place Place_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Place"
    ADD CONSTRAINT "Place_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Place" DROP CONSTRAINT "Place_pkey";
       public            postgres    false    225            S           2606    57598    Tags Tag_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public."Tags"
    ADD CONSTRAINT "Tag_pkey" PRIMARY KEY ("Id");
 ;   ALTER TABLE ONLY public."Tags" DROP CONSTRAINT "Tag_pkey";
       public            postgres    false    226            U           2606    57600    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    228            d           2606    57601    Message ReceiverId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "ReceiverId" FOREIGN KEY ("ReceiverId") REFERENCES public."User"("Id") NOT VALID;
 @   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "ReceiverId";
       public          postgres    false    4693    223    228            e           2606    57606    Message SenderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "SenderId" FOREIGN KEY ("SenderId") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "SenderId";
       public          postgres    false    4693    228    223            `           2606    57611    Match fk_GameId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_GameId" FOREIGN KEY ("GameId") REFERENCES public."Game"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_GameId";
       public          postgres    false    219    222    4679            ]           2606    57616    Game fk_Matches    FK CONSTRAINT     �   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "fk_Matches" FOREIGN KEY ("Matches") REFERENCES public."Match"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "fk_Matches";
       public          postgres    false    4683    222    219            a           2606    57621    Match fk_PlaceId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_PlaceId" FOREIGN KEY ("PlaceId") REFERENCES public."Place"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_PlaceId";
       public          postgres    false    4689    225    222            W           2606    57626    Fighter fk_TagId1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_TagId1" FOREIGN KEY ("TagId1") REFERENCES public."Tags"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_TagId1";
       public          postgres    false    226    4691    217            X           2606    57631    Fighter fk_TagId2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_TagId2" FOREIGN KEY ("TagId2") REFERENCES public."Tags"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_TagId2";
       public          postgres    false    217    226    4691            Y           2606    57636    Fighter fk_TagId3    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_TagId3" FOREIGN KEY ("TagId3") REFERENCES public."Tags"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_TagId3";
       public          postgres    false    217    226    4691            Z           2606    57641    Fighter fk_TagId4    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_TagId4" FOREIGN KEY ("TagId4") REFERENCES public."Tags"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_TagId4";
       public          postgres    false    4691    226    217            [           2606    57646    Fighter fk_TagId5    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_TagId5" FOREIGN KEY ("TagId5") REFERENCES public."Tags"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_TagId5";
       public          postgres    false    217    4691    226            \           2606    57651    Fighter fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    228    4693    217            V           2606    57656    Admin fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    228    4693    215            b           2606    57661    Match fk_UserId1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId1" FOREIGN KEY ("UserId1") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId1";
       public          postgres    false    222    228    4693            c           2606    57666    Match fk_UserId2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId2" FOREIGN KEY ("UserId2") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId2";
       public          postgres    false    222    228    4693            ^           2606    57671    Likes fr_LikedFighterId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "fr_LikedFighterId" FOREIGN KEY ("LikedFighterId") REFERENCES public."Fighter"("Id");
 E   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "fr_LikedFighterId";
       public          postgres    false    217    220    4677            _           2606    57676    Likes fr_LikerId    FK CONSTRAINT     {   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "fr_LikerId" FOREIGN KEY ("LikerId") REFERENCES public."Fighter"("Id");
 >   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "fr_LikerId";
       public          postgres    false    4677    217    220            �   )   x�3�LL����41�2�0�8M��!lC#cNS�=... ��	�      �     x�e�Mj�0FןO�iƖ�3r�@���r\Nm��홺��U�[�X�g���oTc��[\�����Ta����
�o�F3��1��f�=��7��4F�!i�n�TgN�6	�	�L�p�����vj�2B'Ȕ)�"/��p�X��$��V!������[o"#��B:p&i�$ƺ��<��ڹ�"������J��G�8�A-a�XB��a��,a�y������YB#��y��Jh�L:	��Sj	k�������,J���l��������h�      �      x������ � �      �   x   x�E���0�P����I/�� �����,ဠvjI&�zC���l�
ՙtҵIC�r	���Xy"S,���0m�"�k?�(nķ���oZ��˴���y�Yb�m���5������)�      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �             x�3�LIM�/�)������� 2��         �   x�E�Kn�0D��a"l��3d��H���d�νf�@nwyF��~m��`
�%���],�V�R�ǏX8�0�c��MXl~�F�k^��&P��m��[���;��:�t�TXlC�I�S��gw�[��n���"s��#��;9����~�o�p`��@}(%�N�¥!AL
���(���'��(y�'��	��~gDc���8Ϙ�Q
̋@)�y�R���b�J�!�{D?�$I�X��$     