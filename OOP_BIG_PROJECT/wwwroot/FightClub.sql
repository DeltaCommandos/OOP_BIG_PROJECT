PGDMP                       |         
   FightClub1    16.3    16.3 2    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    49524 
   FightClub1    DATABASE     �   CREATE DATABASE "FightClub1" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FightClub1";
                postgres    false            �            1259    49525    Admin    TABLE     o   CREATE TABLE public."Admin" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "UserId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false            �            1259    49530    Admin_Id_seq    SEQUENCE     �   ALTER TABLE public."Admin" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Admin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    49531    Fighter    TABLE     �   CREATE TABLE public."Fighter" (
    "Id" integer NOT NULL,
    "Name" character varying,
    "Rating" integer,
    "Sex" boolean,
    "Age" integer,
    "Skills" character varying,
    "UserId" integer
);
    DROP TABLE public."Fighter";
       public         heap    postgres    false            �            1259    49536    Fighter_Id_seq    SEQUENCE     �   ALTER TABLE public."Fighter" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Fighter_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217            �            1259    49537    Game    TABLE     �   CREATE TABLE public."Game" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Matches" integer NOT NULL
);
    DROP TABLE public."Game";
       public         heap    postgres    false            �            1259    49542    Likes    TABLE     �   CREATE TABLE public."Likes" (
    "Id" integer NOT NULL,
    "LikerId" integer NOT NULL,
    "LikedFighterId" integer NOT NULL,
    "IsLiked" boolean NOT NULL
);
    DROP TABLE public."Likes";
       public         heap    postgres    false            �            1259    49545    Likes_Id_seq    SEQUENCE     �   ALTER TABLE public."Likes" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Likes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    49546    Match    TABLE       CREATE TABLE public."Match" (
    "Id" integer NOT NULL,
    "UserId1" integer NOT NULL,
    "UserId2" integer NOT NULL,
    "GameId" integer NOT NULL,
    "PlaceId" integer NOT NULL,
    "IsAccepted" boolean NOT NULL,
    "ScheduledTime" time without time zone NOT NULL
);
    DROP TABLE public."Match";
       public         heap    postgres    false            �            1259    49549    Message    TABLE     �   CREATE TABLE public."Message" (
    "Id" integer NOT NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "Content" character varying NOT NULL,
    "Timestamp" timestamp with time zone NOT NULL
);
    DROP TABLE public."Message";
       public         heap    postgres    false            �            1259    49554    Person    TABLE     �   CREATE TABLE public."Person" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "AccountId" integer NOT NULL
);
    DROP TABLE public."Person";
       public         heap    postgres    false            �            1259    49559    Place    TABLE     �   CREATE TABLE public."Place" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "Location" character varying NOT NULL
);
    DROP TABLE public."Place";
       public         heap    postgres    false            �            1259    49564    User    TABLE     �   CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Username" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "AdminStatus" boolean,
    "Status" boolean
);
    DROP TABLE public."User";
       public         heap    postgres    false            �            1259    49569    User_id_seq    SEQUENCE     �   ALTER TABLE public."User" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    226            �          0    49525    Admin 
   TABLE DATA           9   COPY public."Admin" ("Id", "Name", "UserId") FROM stdin;
    public          postgres    false    215   Y9       �          0    49531    Fighter 
   TABLE DATA           ]   COPY public."Fighter" ("Id", "Name", "Rating", "Sex", "Age", "Skills", "UserId") FROM stdin;
    public          postgres    false    217   v9       �          0    49537    Game 
   TABLE DATA           9   COPY public."Game" ("Id", "Name", "Matches") FROM stdin;
    public          postgres    false    219   �=       �          0    49542    Likes 
   TABLE DATA           O   COPY public."Likes" ("Id", "LikerId", "LikedFighterId", "IsLiked") FROM stdin;
    public          postgres    false    220   �=       �          0    49546    Match 
   TABLE DATA           q   COPY public."Match" ("Id", "UserId1", "UserId2", "GameId", "PlaceId", "IsAccepted", "ScheduledTime") FROM stdin;
    public          postgres    false    222   �>       �          0    49549    Message 
   TABLE DATA           [   COPY public."Message" ("Id", "SenderId", "ReceiverId", "Content", "Timestamp") FROM stdin;
    public          postgres    false    223   �>       �          0    49554    Person 
   TABLE DATA           =   COPY public."Person" ("Id", "Name", "AccountId") FROM stdin;
    public          postgres    false    224   �>       �          0    49559    Place 
   TABLE DATA           ;   COPY public."Place" ("Id", "Name", "Location") FROM stdin;
    public          postgres    false    225   �>       �          0    49564    User 
   TABLE DATA           W   COPY public."User" ("Id", "Username", "Password", "AdminStatus", "Status") FROM stdin;
    public          postgres    false    226   �>       �           0    0    Admin_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Admin_Id_seq"', 1, false);
          public          postgres    false    216            �           0    0    Fighter_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Fighter_Id_seq"', 21, true);
          public          postgres    false    218            �           0    0    Likes_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Likes_Id_seq"', 24, true);
          public          postgres    false    221            �           0    0    User_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."User_id_seq"', 37, true);
          public          postgres    false    227            >           2606    49571    Admin Admin_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    215            @           2606    49573    Fighter Fighter_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "Fighter_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "Fighter_pkey";
       public            postgres    false    217            B           2606    49575    Game Game_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "Game_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "Game_pkey";
       public            postgres    false    219            D           2606    49577    Likes Likes_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "Likes_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "Likes_pkey";
       public            postgres    false    220            F           2606    49579    Match Match_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "Match_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "Match_pkey";
       public            postgres    false    222            H           2606    49581    Message Message_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "Message_pkey" PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "Message_pkey";
       public            postgres    false    223            J           2606    49583    Person Person_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Person"
    ADD CONSTRAINT "Person_pkey" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Person" DROP CONSTRAINT "Person_pkey";
       public            postgres    false    224            L           2606    49585    Place Place_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Place"
    ADD CONSTRAINT "Place_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Place" DROP CONSTRAINT "Place_pkey";
       public            postgres    false    225            N           2606    49587    User User_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    226            X           2606    49588    Message ReceiverId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "ReceiverId" FOREIGN KEY ("ReceiverId") REFERENCES public."User"("Id") NOT VALID;
 @   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "ReceiverId";
       public          postgres    false    4686    223    226            Y           2606    49593    Message SenderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Message"
    ADD CONSTRAINT "SenderId" FOREIGN KEY ("SenderId") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Message" DROP CONSTRAINT "SenderId";
       public          postgres    false    226    223    4686            T           2606    49598    Match fk_GameId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_GameId" FOREIGN KEY ("GameId") REFERENCES public."Game"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_GameId";
       public          postgres    false    222    4674    219            Q           2606    49603    Game fk_Matches    FK CONSTRAINT     �   ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "fk_Matches" FOREIGN KEY ("Matches") REFERENCES public."Match"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Game" DROP CONSTRAINT "fk_Matches";
       public          postgres    false    222    219    4678            U           2606    49608    Match fk_PlaceId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_PlaceId" FOREIGN KEY ("PlaceId") REFERENCES public."Place"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_PlaceId";
       public          postgres    false    4684    222    225            P           2606    49613    Fighter fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Fighter"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 ?   ALTER TABLE ONLY public."Fighter" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    4686    217    226            O           2606    49618    Admin fk_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "fk_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;
 =   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "fk_UserId";
       public          postgres    false    4686    215    226            V           2606    49623    Match fk_UserId1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId1" FOREIGN KEY ("UserId1") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId1";
       public          postgres    false    4686    226    222            W           2606    49628    Match fk_UserId2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Match"
    ADD CONSTRAINT "fk_UserId2" FOREIGN KEY ("UserId2") REFERENCES public."User"("Id") NOT VALID;
 >   ALTER TABLE ONLY public."Match" DROP CONSTRAINT "fk_UserId2";
       public          postgres    false    4686    226    222            R           2606    49633    Likes fr_LikedFighterId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "fr_LikedFighterId" FOREIGN KEY ("LikedFighterId") REFERENCES public."Fighter"("Id");
 E   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "fr_LikedFighterId";
       public          postgres    false    4672    220    217            S           2606    49638    Likes fr_LikerId    FK CONSTRAINT     {   ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT "fr_LikerId" FOREIGN KEY ("LikerId") REFERENCES public."Fighter"("Id");
 >   ALTER TABLE ONLY public."Likes" DROP CONSTRAINT "fr_LikerId";
       public          postgres    false    4672    220    217            �      x������ � �      �   X  x�uV�n�V]�_q�TÔ��O����Z 0��N�k;����m���."K�DQ�����s�R��Ԉ޹Ù3g�s��'����+_�<���nrr|r�̾�fYr��3�A�u��ׯzf?L�^����g�v���%ݣ4{��ʂ#��v�l/	�ۦ,����7'�]$HI[7�����n�4;��테=�^��Qrn�z���ٱ;{u�*���]`�ۏ|�`����_�.f~>���}��<�Ã/��B�*\��OB?\�u�t�������2�_�%ǹ��l�q�~��~���2�*}%�݃�r Q�1C�]�fr9�����p�a�U�	�a��_8���y4g0½��b�����/���T+�� �>|��r�)���
�ۆ��o��/�կ��f�]��4@���g�iN&���/:��2| 2r;E`�.;�&XD�U�;~�q�7p 6/K�n�U�J̠@^�n�\�5��Sa	��W���[�����q��֏g-}@����7J���P)� ������b��b��-�C��Qc�u����ª1:�+����D��k�e,��F@��%��ذ�S�Y�]�"Ix#��Xo��o��,�jS��^}{�I �B:���O��G
��5�7z����P��q�VA��t�Z�ѕ�Q���r��VS%>E��,{2������Qs��c��H�
c��l�t�HD��4��%���/��z�e&Q�-�(k,��pN����`����z#�`�"ܱ�����n�)�"WUk��55��-6	�`PE�q/�1a�6#�l-B�c6㪉M_lE�(�y�`)Ym���P4}�"'�TF"���`ݨ�k#���j��������b���^`�I�E�(Y�C������q���?7�m��wl���}���m��G�nURtl��rsT{<�tVW�r-s�Ij�.w17�Ш��f�1J�Y&���.��U��{a/D*y#؄m���� 3�Ta� ���d��n؄��[�ud����ņ����msN�O�ɱ�4u�iu�K?����s�7UT�q�g� �4�I�6���K�v�㗦���?"����N���C��      �      x������ � �      �   w   x�E���0C�0LUH��.=w���V���HXL�˖�(��B�byݩ�DؤN�.�p��s;�+d�%�F�B5a��/!�������1,5c'QcQ��4x 0?���e�e�߇���L(�      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �   �   x�M�A
1E׿����3z7�`��P��D2�K�3�7�I��|�~6�K��������=��-���c)�8���mW$����p'+#�"D���l1 ������N��4ч�ɪ�4R��|���O��R���Gb     